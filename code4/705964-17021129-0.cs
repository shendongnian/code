    public void Save(string filename, ImageFormat format)
    {
        if (format == null)
        {
            throw new ArgumentNullException("format");
        }
        ImageCodecInfo imageCodecInfo = format.FindEncoder();
        if (imageCodecInfo == null)
        {
            imageCodecInfo = ImageFormat.Png.FindEncoder();
        }
        this.Save(filename, imageCodecInfo, null);
    }
