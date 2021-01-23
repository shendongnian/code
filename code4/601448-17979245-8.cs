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
                Console.WriteLine("FromEncoder: '{0}', FromConverter: '{1}', FromToString: '{2}'", format.FileExtensionFromEncoder(), format.FileExtensionFromConverter(), format.FileExtensionFromToString());
            }
            Console.Read();
        }
    }
