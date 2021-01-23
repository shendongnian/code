    public static ImageFormat GetRawImageFormat(byte[] fileBytes)
    {
        using (var ms = new MemoryStream(fileBytes))
        {
            var fileImage = Image.FromStream(ms);
            return fileImage.RawFormat;
        }
    }
