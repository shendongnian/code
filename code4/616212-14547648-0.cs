        private bool CloseRequested;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            CloseRequested = true;
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing && !CloseRequested) {
                e.Cancel = true;
                this.Hide();
            }
        }
