    renderBitmap.Render(dv);
    BitmapSource bmp =renderBitmap;
    VideoStream aviStream = aviManager.AddVideoStream(true, 60, ConvertToBitmap(bmp));
----------
    private System.Drawing.Bitmap ConvertToBitmap(BitmapSource target)
    {
        System.Drawing.Bitmap bitmap;
        using (MemoryStream outStream = new MemoryStream())
        {
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(target));
            enc.Save(outStream);
            bitmap = new System.Drawing.Bitmap(outStream);
        }
        return bitmap;
    }
 
