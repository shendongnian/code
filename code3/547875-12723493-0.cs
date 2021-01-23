    int newHeight = ActualImgHeight*200/ActualImgWidth;
    Bitmap bmp = new Bitmap(200, newHeight);
    Graphics g = Graphics.FromImage((Image)bmp);
    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
    g.CompositingQuality = CompositingQuality.HighQuality;
    g.SmoothingMode = SmoothingMode.HighQuality;
    g.DrawImage(imgToResize, 0, 0, 200, newHeight);
    g.Dispose();
    bmp.Save(path,System.Drawing.Imaging.ImageFormat.Jpeg);
