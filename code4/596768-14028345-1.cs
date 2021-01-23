    public Stream ImageToStream(Image image, System.Drawing.Imaging.ImageFormat format)
    {
        MemoryStream ms = new MemoryStream();
        image.Save(ms, format);
        return  ms;
    }
