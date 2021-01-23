    int iImageIndex = lvItem.ImageIndex;
    int iIndex = lvItem.Index; 
    for (int i = iIndex + 1; i < listView1.Items.Count; i++) // correct the image indicies
        listView1.Items[i].ImageIndex--;       
    lvItem.Remove(); // repaint
    Image img = ImageList1.Images[iImageIndex];
    ImageList1.Images.RemoveAt(iImageIndex);
    img.Dispose();
