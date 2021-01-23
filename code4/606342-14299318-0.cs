    private static async Task<Bitmap> TakeScreenshotAsync()
    {
      var screenRect = Screen.PrimaryScreen.Bounds;
      return await TakeScreenshotAsync(screenRect);
    }
    private static async Task<Bitmap> TakeScreenshotAsync(Rectangle bounds)
    {
      var screenShot = new Bitmap(bounds.Width, bounds.Height, 
                                  PixelFormat.Format32bppArgb);
      // This executes on a ThreadPool thread asynchronously!
      await Task.Run(() =>
      {
        using (var g = Graphics.FromImage(screenShot))
          g.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size);
      });
      return screenShot;
    }
