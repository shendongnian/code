    class Program
    {
        static void Main()
        {
            var formats = new[]
            {
                ImageFormat.Bmp, ImageFormat.Emf, ImageFormat.Exif, ImageFormat.Gif,
                ImageFormat.Icon, ImageFormat.Jpeg, ImageFormat.MemoryBmp, ImageFormat.Png,
                ImageFormat.Tiff, ImageFormat.Wmf
            };
            foreach (var format in formats)
            {
                Console.WriteLine("Encoder method produced '{0}' and converter method produced '{1}'", format.FileExtensionFromEncoder(), format.FileExtensionFromConverter());
            }
            Console.Read();
        }
    }
    static class ImageFormatUtils
    {
        public static string FileExtensionFromEncoder(this ImageFormat format)
        {
            try
            {
                var e = ImageCodecInfo.GetImageEncoders()
                    .First(x => x.FormatID == format.Guid)
                    .FilenameExtension
                    .Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                return e.First().ToLower().Trim('*');
            }
            catch (Exception)
            {
                return ".IDFK";
            }
        }
        public static string FileExtensionFromConverter(this ImageFormat format)
        {
            try
            {
                return "." + new ImageFormatConverter().ConvertToString(format).ToLower();
            }
            catch (Exception)
            {
                return ".IDFK";
            }
        }
    }
