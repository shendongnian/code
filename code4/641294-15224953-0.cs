    using ImageTools.IO.Png;
    using ImageTools;
    public static byte[] ToPng(this WriteableBitmap Image)
    {
        byte[] bytResult;
        using (MemoryStream objPngStream = new MemoryStream())
        {
            PngEncoder objPngEncoder = new PngEncoder();
            objPngEncoder.Encode(Image.ToImage(), objPngStream);
            objPngStream.Seek(0, SeekOrigin.Begin);
            bytResult = objPngStream.ToArray();
            objPngStream.Close();
        }
        return bytResult;
    }
