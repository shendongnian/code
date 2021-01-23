    public static byte[] EncodeImage(BitmapImage bitmapImage)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            encoder.Save(memoryStream);
            return memoryStream.ToArray();
        }
    }
