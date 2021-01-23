    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        foreach (ListViewItem itm in listView1.SelectedItems)
        {
            pictureBox1.Image = System.Drawing.Image.FromFile(itm.SubItems[0].Text);
        }
    }
