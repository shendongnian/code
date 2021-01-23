    public BitmapImage ImageFromBuffer(Byte[] bytes)
    {
        MemoryStream stream = new MemoryStream(bytes);
        BitmapImage image = new BitmapImage();
        image.BeginInit();
        image.StreamSource = stream;
        image.EndInit();
        return image;
    }
    public Byte[] BufferFromImage(BitmapImage imageSource)
    {
        Stream stream = imageSource.StreamSource;
        Byte[] buffer = null;
        if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                    {
                        buffer = br.ReadBytes((Int32)stream.Length);
                    }
            }
        return buffer;
    }
