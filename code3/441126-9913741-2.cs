    public ImageSource SourceItem
    {
      get
      {
        BitmapImage image = new BitmapImage();
        image.SetSource(isStore.OpenFile(PhotoItem, FileMode.Open));  
        return image;
      }
    }
