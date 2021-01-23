    public static Bitmap BitmapImageToBitmap(BitmapImage bitmapImage)
    {
        Bitmap bitmap;
    
        using (var ms = new MemoryStream())
        {
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            encoder.Save(ms);
    
            using (var localBitmap = new Bitmap(ms))
            {
                bitmap = localBitmap.Clone(new Rectangle(0, 0, localBitmap.Width, localBitmap.Height),
                       localBitmap.PixelFormat);
            }
        }
    
        return bitmap;
    }
