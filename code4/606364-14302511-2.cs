    public static byte[] ToByteArray(this BitmapSource bitmap)
    {
        var encoder = new PngBitmapEncoder(); // or any other encoder
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using (var ms = new MemoryStream())
        {
            encoder.Save(ms);
            return ms.ToArray();
        }
    }
