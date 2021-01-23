    public static Color GetPixelColor(BitmapSource bitmap, int x, int y)
    {
        Color color;
        var bytesPerPixel = (bitmap.Format.BitsPerPixel + 7) / 8;
        var bytes = new byte[bytesPerPixel];
        var rect = new Int32Rect(x, y, 1, 1);
        bitmap.CopyPixels(rect, bytes, bytesPerPixel, 0);
        if (bitmap.Format == PixelFormats.Pbgra32)
        {
            color = Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
        }
        else if (bitmap.Format == PixelFormats.Bgr32)
        {
            color = Color.FromArgb(0xFF, bytes[2], bytes[1], bytes[0]);
        }
        // handle other required formats
        else
        {
            color = Colors.Black;
        }
        return color;
    }
