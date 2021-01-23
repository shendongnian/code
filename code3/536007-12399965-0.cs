    private void PopulatePictureBox()
    {
     ImageList images = new ImageList();
     images.Images.Add(LoadImage("http://www.website.com/123.jpg"));
     picbox.Image = imagelst.Images[0];
    }
