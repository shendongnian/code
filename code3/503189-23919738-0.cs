    public BitmapImage ToBitmapImage(Bitmap bitmap)
    {
      using (MemoryStream stream = new MemoryStream())
      {
        bitmap.Save(stream, ImageFormat.Png); // Was .Bmp, but this did not show a transparent background.
        stream.Position = 0;
        BitmapImage result = new BitmapImage();
        result.BeginInit();
        // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
        // Force the bitmap to load right now so we can dispose the stream.
        result.CacheOption = BitmapCacheOption.OnLoad;
        result.StreamSource = stream;
        result.EndInit();
        result.Freeze();
        return result;
      }
    }
