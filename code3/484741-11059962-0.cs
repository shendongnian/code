        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl1.SelectedIndex == 1) {
                this.BeginInvoke(new Action(() => tabControl1.SelectTab(0)));
            }
        }
