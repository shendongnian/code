    private void TakeScreenshot_Click(object sender, EventArgs e)
    {
      TakeScreenshotAsync(OnScreenshotTaken);
    }
    private static void OnScreenshotTaken(Bitmap screenshot)
    {
      using (screenshot)
        screenshot.Save("screenshot.png", ImageFormat.Png);
    }
    private static void TakeScreenshotAsync(Action<Bitmap> callback)
    {
      var screenRect = Screen.PrimaryScreen.Bounds;
      TakeScreenshotAsync(screenRect, callback);
    }
    private static void TakeScreenshotAsync(Rectangle bounds, Action<Bitmap> callback)
    {
      var screenshot = new Bitmap(bounds.Width, bounds.Height,
                                  PixelFormat.Format32bppArgb);
      ThreadPool.QueueUserWorkItem((state) =>
      {
        using (var g = Graphics.FromImage(screenshot))
          g.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size);
        if (callback != null)
          callback(screenshot);
      });
    }
