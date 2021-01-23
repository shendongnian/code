    var topLeftCorner = MainBrowser.PointToScreen(new System.Drawing.Point(0, 0));
    var topLeftGdiPoint = new System.Drawing.Point((int)topLeftCorner.X, (int)topLeftCorner.Y);
    var size = new System.Drawing.Size((int)MainBrowser.ActualWidth, (int)MainBrowser.ActualHeight);
    Bitmap screenShot = new Bitmap((int)MainBrowser.ActualWidth, (int)MainBrowser.ActualHeight);
    using (var graphics = Graphics.FromImage(screenShot))
    {
        graphics.CopyFromScreen(topLeftGdiPoint, new System.Drawing.Point(), size, CopyPixelOperation.SourceCopy);
    }
    screenShot.Save(@"D:\Temp\screenshot.png");
