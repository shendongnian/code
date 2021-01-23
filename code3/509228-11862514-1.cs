    public static BitmapSource GetBitmap(float[] pixels, ImageProperties properties)
    {
        var bmp = new WriteableBitmap(properties.Rows, properties.Columns);
        using (var stream = bmp.PixelBuffer.AsStream())
        {
            var bytes = new byte[4 * pixels.Length];
            for (int i = 0; i < pixels.Length; i++)
            {
                var greyness = properties.WindowAndLevel.GetValue(pixels[i]);
                bytes[4 * i] = greyness;
                bytes[4 * i + 1] = greyness;
                bytes[4 * i + 2] = greyness;
                bytes[4 * i + 3] = 0xff;
            }
            stream.Write(bytes, 0, bytes.Length);
        }
        return bmp;
    }
