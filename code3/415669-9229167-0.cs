        private void listBox1_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var item = listBox1.IndexFromPoint(e.Location);
                if (item >= 0) {
                    listBox1.SelectedIndex = item;
                    contextMenuStrip1.Show(listBox1, e.Location);
                }
            }
        }
