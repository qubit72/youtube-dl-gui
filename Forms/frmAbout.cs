﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAbout : Form {
        Language lang = Language.GetInstance();
        GitData GitCloud = GitData.GetInstance();

        public frmAbout() {
            InitializeComponent();
            this.Icon = Properties.Resources.youtube_dl_gui;
        }
        private void frmAbout_Shown(object sender, EventArgs e) {
            if (!Properties.Settings.Default.jsonSupport)
                llbCheckForUpdates.Enabled = false;

            lbVersion.Text = "v" + Properties.Settings.Default.appVersion.ToString();
            lbBody.Text = lbBody.Text.Replace("{DEBUG}", Properties.Settings.Default.debugDate);
        }

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (!Properties.Settings.Default.jsonSupport)
                return;

            UpdateChecker.CheckForUpdate(true);
        }
        private void pbIcon_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui/");
        }

        private void llbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui");
        }
    }
}
