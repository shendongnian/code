	var listView = new ListView();
	
	// create image list and fill it 
	var imageList = new ImageList();
	imageList.Images.Add("itemImageKey", image);
	// tell your ListView to use the new image list
	listView.LargeImageList = imageList;
	// add an item
	var listViewItem = listView.Items.Add("Item with image");
	// and tell the item which image to use
	listViewItem.ImageKey = "itemImageKey";
