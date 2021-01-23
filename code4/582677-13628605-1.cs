    public BitmapImage AlbumSource
    {
        get
        {
           BitmapImage bmp = new BitmapImage();
           bmp.SetSource(AlbumThumbnail.OpenReadAsync().GetResults());
           return bmp;
        }
    }
