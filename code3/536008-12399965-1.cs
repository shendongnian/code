    private void PopulateListView()
    {
        ImageList images = new ImageList();
        images.Images.Add(LoadImage("http://www.website.com/123.jpg"));
        images.Images.Add(LoadImage("http://www.website.com/456.jpg"));
        listView1.SmallImageList = images;
        listView1.Items.Add("An item", 0);
        listView1.Items.Add("Another item item", 1);
    }
    
