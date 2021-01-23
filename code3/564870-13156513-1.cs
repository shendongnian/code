    protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (!e.Cancel) {
                if (MessageBox.Show("Do you want to close this application?", "Close Application", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                    e.Cancel = true;
                }
            }
        }
