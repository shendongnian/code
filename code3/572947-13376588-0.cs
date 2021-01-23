    listView1.View = View.LargeIcon;
    imageList.ImageSize = new Size(100, 100);
    foreach(var fileName in opend1.FileNames)
    {
        Image img = Image.FromFile(fileName);
        imageList.Images.Add(img.GetThumbnailImage(100, 100, null, new IntPtr()));
    }
    listView1.LargeImageList = imageList;
    for (int index = 0; index < imageList.Images.Count; index++)
         listView1.Items.Add(new ListViewItem() { ImageIndex = index });
    listView1.Refresh();
