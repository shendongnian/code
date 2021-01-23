    public string GetFilenameExtension(ImageFormat format)
    {
        return ImageCodecInfo.GetImageEncoders()
                             .First(x => x.FormatID == format.Guid)
                             .FilenameExtension
                             .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                             .First()
                             .Trim('*');
    }
