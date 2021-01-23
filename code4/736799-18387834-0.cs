    using (MagickImageCollection collection = new MagickImageCollection())
    {
      MagickReadSettings settings = new MagickReadSettings();
      settings.FrameIndex = 0; // First page
      settings.FrameCount = 1; // Number of pages
      
      collection.Read("Snakeware.pdf", settings);
    }
