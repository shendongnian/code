    private void SaveBrowserScreenshot(WebBrowser browser, string path, string name)
    {
        const string extension = ".png";
        int width = Math.Max(1024, Screen.PrimaryScreen.Bounds.Width);
        int height = Math.Max(768, Screen.PrimaryScreen.Bounds.Height);
        int originalWidth = browser.Width;
        int originalHeight = browser.Heignt;
        browser.Width = width;
        browser.Heigt = height;
    
        using (var bitmap = new Bitmap(width, height))
        {
            var rect = new Rectangle(0, 0, width, height);
            browser.DrawToBitmap(bitmap, rect);
    
            using (var image = bitmap)
            {
                using (var graphic = Graphics.FromImage(image))
                {
                    graphic.CompositingQuality = CompositingQuality.HighQuality;
                    graphic.SmoothingMode = SmoothingMode.HighQuality;
                    graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
    
                    image.Save(String.Concat(path, "\\", name, extension), ImageFormat.Png);
                }
            }
        }
        browser.Width = originalWidth;
        browser.Height = originalHeight;
    }
