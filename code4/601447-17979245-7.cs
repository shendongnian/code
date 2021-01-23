    static class ImageFormatUtils
    {
        //Attempt 1: Use ImageCodecInfo.GetImageEncoders
        public static string FileExtensionFromEncoder(this ImageFormat format)
        {
            try
            {
                return ImageCodecInfo.GetImageEncoders()
                        .First(x => x.FormatID == format.Guid)
                        .FilenameExtension
                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .First()
                        .Trim('*')
                        .ToLower();
            }
            catch (Exception)
            {
                return ".IDFK";
            }
        }
        //Attempt 2: Using ImageFormatConverter().ConvertToString()
        public static string FileExtensionFromConverter(this ImageFormat format)
        {
            return "." + new ImageFormatConverter().ConvertToString(format).ToLower();
        }
        //Attempt 3: Using ImageFormat.ToString()
        public static string FileExtensionFromToString(this ImageFormat format)
        {
            return "." + format.ToString().ToLower();
        }
    }
