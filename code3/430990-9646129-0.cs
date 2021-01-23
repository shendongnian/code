        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (!e.Cancel) {
                if (MessageBox.Show("Really?", "Close", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                    e.Cancel = true;
                }
            }
        }
