        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e) {
            if (e.TabPageIndex == 0 && tabControl1.TabCount > 1) {
                tabControl1.TabPages[1].Dispose();
                e.Cancel = true;
            }
        }
