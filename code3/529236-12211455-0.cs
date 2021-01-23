    private void saveAsPNG(ImageFrame myImageFrame, string path)
    {
       Bitmap bmp = myImageFrame.ToBitmap();
       bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
       bmp.Dispose();
    }
