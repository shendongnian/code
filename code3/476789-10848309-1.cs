    Bitmap ImageToBitmap(ColorImageFrame img)
    {
         byte[] pixeldata = new byte[img.PixelDataLength];
         img.CopyPixelDataTo(pixeldata);
         Bitmap bmap = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppRgb);
         BitmapData bmapdata = bmap.LockBits(
             new Rectangle(0, 0, img.Width, img.Height),
             ImageLockMode.WriteOnly, 
             bmap.PixelFormat);
         IntPtr ptr = bmapdata.Scan0;
         Marshal.Copy(pixeldata, 0, ptr, img.PixelDataLength);
         bmap.UnlockBits(bmapdata);
         return bmap;
     }
