    int _selectedIndex;
    private void listBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right) {
            _selectedIndex = listBox1.IndexFromPoint(e.Location);
            if (_selectedIndex == -1) {
                return;
            }
            contextMenuStrip1.Show(listBox1.PointToScreen(e.Location));
        }
    }
