    protected int GetIndexedPixel(int x, int y, BitmapData bmd)
    {
        var index = y * bmd.Stride + (x >> 3);
        var p = Marshal.ReadByte(bmd.Scan0, index);
        var mask = (byte)(0x80 >> (x & 0x7));
        return p &= mask;
    }
    protected void SetIndexedPixel(int x, int y, BitmapData bmd, bool pixel)
    {
        int index = y * bmd.Stride + (x >> 3);
        byte p = Marshal.ReadByte(bmd.Scan0, index);
        byte mask = (byte)(0x80 >> (x & 0x7));
        if (pixel)
            p &= (byte)(mask ^ 0xff);
        else
            p |= mask;
        Marshal.WriteByte(bmd.Scan0, index, p);
    }
    public DocAppImage CutToNew(int left, int top, int width, int height, int pageWidth, int pageHeight)
    {
        var destBmp = new Bitmap(pageWidth, pageHeight, BitmapImage.PixelFormat);
        var pageRect = new Rectangle(0, 0, pageWidth, pageHeight);
        var pageData = destBmp.LockBits(pageRect, ImageLockMode.WriteOnly, BitmapImage.PixelFormat);
        var croppedRect = new Rectangle(0, top, width, height);
        var croppedSource = BitmapImage.LockBits(croppedRect, ImageLockMode.ReadWrite, BitmapImage.PixelFormat);
        for (var y = 0; y < pageHeight; y++)
            for (var x = 0; x < pageWidth; x++)
            {
                if (y >= top && y <= top + height && x >= left && x <= width + left)
                {
                    SetIndexedPixel(x, y, pageData,
                                    GetIndexedPixel(x, y - top, croppedSource) == 0 ? true : false);
                    SetIndexedPixel(x, y - top, croppedSource, false); //Blank area in original
                }
                else
                    SetIndexedPixel(x, y, pageData, false);  //Fill the remainder of the page with white.
            }
        destBmp.UnlockBits(pageData);
        var retVal = new DocAppImage { BitmapImage = destBmp };
        destBmp.Dispose();
        BitmapImage.UnlockBits(croppedSource);
        SaveBitmapToFileImage(BitmapImage);
        return retVal;
    }
