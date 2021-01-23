    namespace TiffExample
    {
        using System;
        using System.IO;
        using System.Windows.Media;
        using System.Windows.Media.Imaging;
        public static class Program
        {
            private const int bytesPerPixel = 4; // This constant must correspond with the pixel format of the converted bitmap.
            private static void Main()
            {
                var stream = File.Open("example.tif", FileMode.Open);
                var tiffDecoder = new TiffBitmapDecoder(
                    stream,
                    BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreImageCache,
                    BitmapCacheOption.None);
                stream.Dispose();
                var firstFrame = tiffDecoder.Frames[0];
                var convertedBitmap = new FormatConvertedBitmap(firstFrame, PixelFormats.Bgra32, null, 0);
                var width = convertedBitmap.PixelWidth;
                var height = convertedBitmap.PixelHeight;
                var bytes = new byte[width * height * bytesPerPixel];
                convertedBitmap.CopyPixels(bytes, width * bytesPerPixel, 0);
                Console.WriteLine(GetPixel(bytes, 548, 314, width));
                Console.ReadKey();
            }
            private static Color GetPixel(byte[] bgraBytes, int x, int y, int width)
            {
                var index = (y * (width * bytesPerPixel) + (x * bytesPerPixel));
                return Color.FromArgb(
                    bgraBytes[index + 3],
                    bgraBytes[index + 2],
                    bgraBytes[index + 1],
                    bgraBytes[index]);
            }
        }
    }
