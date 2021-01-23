     -Create a new imagelist (imagelist1)**
     -Add images to your imagelist 
     -Create a new listview (listview1)
     -Create a picturebox (picturebox1)
     -Create a new button (button1)
     -Create another button (button2)**
      -Import  images from imagelist1 to listview1
    private void button1_Click(object sender, EventArgs e)
    {
        listView1.Scrollable = true;
        listView1.View = View.LargeIcon;
        imageList1.ImageSize = new Size(100, 100);
        listView1.LargeImageList = imagelist1;
        for (int i = 0; i < imagelist1.Images.Count; ++i)
        {
            string s = imagelist1.Images.Keys[i].ToString();
            ListViewItem lstItem = new ListViewItem();
            lstItem.ImageIndex = i;
            lstItem.Text = s;
            listView1.Items.Add(lstItem);
        }
    }
     - Set the selected image into your picture box from listview
      private void button2_Click(object sender, EventArgs e)
    {
        if (this != null && listView1.SelectedItems.Count > 0)
        {
            ListViewItem lvi = listView1.SelectedItems[0];
            string imagekeyname = lvi.Text;
            if (this.pictureBox1.Image != null)
            {
                this.pictureBox1.Image.Dispose();
                this.pictureBox1.Image = null;
            }
            //set the selected image into your picturebox
            this.pictureBox1.Image = imagelist1.Images[imagekeyname];
        }
    }
