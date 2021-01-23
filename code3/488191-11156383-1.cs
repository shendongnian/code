    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Media.Imaging;
    
    class Program
    {
        static void Main()
        {
            using (var stream = File.OpenRead(@"c:\work\some_huge_image.tif"))
            {
                var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.None);
                var frame = decoder.Frames.First();
                Console.WriteLine(
                    "width: {0}, height: {1}", 
                    frame.PixelWidth, 
                    frame.PixelHeight
                );
            }
        }
    }
