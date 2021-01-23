    img.Source = ImageFromRelativePath(this, "Assets/Images/back.png");
    
    public static BitmapImage ImageFromRelativePath(FrameworkElement parent, string path)
    {
        var uri = new Uri(parent.BaseUri, path);
        BitmapImage bmp = new BitmapImage();
        bmp.UriSource = uri;
        return bmp;
    }
