    public static string ToBased64String(this Image image, ImageFormat format)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        image.Save(ms, format);
        byte[] imageBytes = ms.ToArray();
        string based64String = Convert.ToBased64String(imageBytes);
        return based64String;
    
      }
    }
