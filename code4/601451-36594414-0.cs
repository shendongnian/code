    public static string GetFileExtension(this ImageFormat imageFormat)
    {
        var extension = ImageCodecInfo.GetImageEncoders()
            .Where(ie => ie.FormatID == imageFormat.Guid)
            .Select(ie => ie.FilenameExtension
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .First()
                .Trim('*')
                .ToLower())
            .FirstOrDefault();
        return extension ?? string.Format(".{0}", imageFormat.ToString().ToLower());
    }
