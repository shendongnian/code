    List<ImageGallery> _list = new List<ImageGallery>(); 
    for (int i = 0; i < ListView1.Items.Count; i++) 
    {
        Image image = (Image)ListView1.Items[i].FindControl("capty");
        ImageGallery ob = new ImageGallery(); 
        ob.ImageName = ""; 
        ob.Description = image.AlternateText; 
        _list.Add(ob); 
    }
