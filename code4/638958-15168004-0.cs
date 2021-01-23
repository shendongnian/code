    void listView1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        updateToolStripMenuItem.Enabled = (listView1.Items.Count > 0);
      }
    }
