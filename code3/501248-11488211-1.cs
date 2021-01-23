    public static byte[] ImageToByteArray(Image imageIn)
    {
        var ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        return ms.ToArray();
    }
    public static Image ByteArrayToImage(byte[] byteArrayIn)
    {
        var ms = new MemoryStream(byteArrayIn);
        Image returnImage = Image.FromStream(ms);
        return returnImage;
    }
