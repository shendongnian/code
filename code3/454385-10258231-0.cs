    private static unsafe void OnlyRed(Bitmap bitmap, Color replacement)
    {
        var redOffset = 0;
        var bpp = 32;
        var bytesRep = new List<byte> {replacement.R, replacement.G, replacement.B};
        switch (bitmap.PixelFormat)
        {
            case PixelFormat.Format24bppRgb:
                bpp = 24;
                break;
            case PixelFormat.Format32bppArgb:
                redOffset = 8;
                bytesRep.Insert(0, replacement.A);
                break;
            case PixelFormat.Format32bppRgb:
            case PixelFormat.Canonical:
                bytesRep.Add(replacement.A);
                break;
            default:
                throw new NotSupportedException("Pixel format unsupported.");
        }
        var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                   ImageLockMode.ReadWrite,
                                   bitmap.PixelFormat);
        var start = (byte*)data.Scan0;
        var end = start + data.Height * data.Stride;
        for (var curr = start; curr < end; curr += bpp / 8)
        {
            if (curr[redOffset] > 200)
            {
                continue;
            }
            
            for (var i = 0; i < bytesRep.Count; i++)
            {
                curr[i] = bytesRep[i];
            }
        }
        bitmap.UnlockBits(data);
    }
