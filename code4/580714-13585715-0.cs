    public BitmapImage Image { get; private set; }
    public async Task Load()
    {
      Image = await ConnectImage.GetImageAsync(...);
      ... // other asynchronously-loaded properties
    }
