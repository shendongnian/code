        private void OptionChangeColor_Click(object sender, EventArgs e) {
            using (var dlg = new ColorDialog()) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    this.BackColor = Properties.Settings.Default.FormBackColor = dlg.Color;
                    Properties.Settings.Default.Save();
                }
            }
        }
