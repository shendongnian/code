    public ImageSource
    {
      get
      {
        BitmapImage image = new BitmapImage();
        image.SetSource(isStore.OpenFile(fileName, FileMode.Open));  
        return image;
      }
    }
