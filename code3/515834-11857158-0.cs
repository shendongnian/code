    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        foreach (ListViewItem itm in listView1.SelectedItems)
        {
            int imgIndex = itm.ImageIndex;
            if ( imgIndex >= 0 && imgIndex < this.imageList1.images.Count)
            {
                pictureBox1.Image = this.imageList1.images[imgIndex];
            }
        }
    }
