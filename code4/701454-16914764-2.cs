    private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
    {
        var outStream = new MemoryStream();  
        var enc = new BmpBitmapEncoder();
        enc.Frames.Add(BitmapFrame.Create(bitmapImage));
        enc.Save(outStream);
        return new System.Drawing.Bitmap(outStream);
    }
