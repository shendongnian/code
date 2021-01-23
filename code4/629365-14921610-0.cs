        private void listBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var idx = listBox1.IndexFromPoint(e.Location);
                if (idx >= 0 && listBox1.GetItemRectangle(idx).Contains(e.Location)) {
                    listBox1.SelectedIndex = idx;
                    contextMenuStrip1.Show(listBox1, e.Location);
                }
            }
        }
