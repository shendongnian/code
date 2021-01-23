        private void DisplayDialog_Click(object sender, EventArgs e) {
            using (var dlg = new Form2()) {
                this.BeginInvoke(new Action(() => this.Hide()));
                dlg.FormClosing += dlg_FormClosing;
                dlg.StartPosition = FormStartPosition.Manual;
                dlg.Location = this.Location;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    // etc..
                }
                dlg.FormClosing -= dlg_FormClosing;
            }
        }
        void dlg_FormClosing(object sender, FormClosingEventArgs e) {
            if (!e.Cancel) this.Show();
        }
