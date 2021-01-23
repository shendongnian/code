    private void BitmapInvertColors(Bitmap bitmapImage)
    {
        var bitmapRead = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
        int bitmapSize = bitmapRead.Stride * bitmapRead.Height;
        var bitmapBGRA = new byte[bitmapSize];
        System.Runtime.InteropServices.Marshal.Copy(bitmapRead.Scan0, bitmapBGRA, 0, bitmapSize);
        bitmapImage.UnlockBits(bitmapRead);
        for (int i = 0; i < bitmapBGRA.Length; i+= 4)
        {
            bitmapBGRA[i]     = (byte)(255 - bitmapBGRA[i]);
            bitmapBGRA[i + 1] = (byte)(255 - bitmapBGRA[i + 1]);
            bitmapBGRA[i + 2] = (byte)(255 - bitmapBGRA[i + 2]);
            //        [i + 3] = ALPHA.
        }
        var bitmapWrite = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
        System.Runtime.InteropServices.Marshal.Copy(bitmapBGRA, 0, bitmapWrite.Scan0, bitmapSize);
        bitmapImage.UnlockBits(bitmapWrite);
    }
