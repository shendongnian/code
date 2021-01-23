    public static string CreateGRF(string filename, string imagename)
    {
        Bitmap bmp = null;
        BitmapData imgData = null;
        byte[] pixels;
        int x, y, width;
        StringBuilder sb;
        IntPtr ptr;
        try
        {
            bmp = new Bitmap(filename);
            imgData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
            width = (bmp.Width + 7) / 8;
            pixels = new byte[width];
            sb = new StringBuilder(width * bmp.Height * 2);
            ptr = imgData.Scan0;
            for (y = 0; y < bmp.Height; y++)
            {
                Marshal.Copy(ptr, pixels, 0, width);
                for (x = 0; x < width; x++)
                    sb.AppendFormat("{0:X2}", (byte)~pixels[x]);
                ptr = (IntPtr)(ptr.ToInt64() + imgData.Stride);
            }
        }
        finally
        {
            if (bmp != null)
            {
                if (imgData != null) bmp.UnlockBits(imgData);
                bmp.Dispose();
            }
        }
        return String.Format("~DG{0}.GRF,{1},{2},", imagename, width * y, width) + sb.ToString();
    }
