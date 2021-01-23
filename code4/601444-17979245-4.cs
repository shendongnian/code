    static class ImageFormatUtils
    {
        public static string FileExtension(this ImageFormat format)
        {
            return ImageCodecInfo.GetImageEncoders()
                .First(x => x.FormatID == format.Guid)
                .FilenameExtension
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .First()
                .Trim('*')
                .ToLower();
        }
    }
