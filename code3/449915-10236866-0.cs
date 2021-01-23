    public ImageSource ApplicationIcon
    {
      get
      {
        return BitmapFrame.Create(new Uri(pathReadFromConfigFile));
      }
    }
