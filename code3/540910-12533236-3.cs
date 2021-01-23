    #region Using Directives
    
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    
    #endregion
    
    namespace TiffToBitmap
    {
        internal class Program
        {
            private static void Main()
            {
                // Just save the image.
                SaveImage(@"C:\Sample1.png", "image/tiff");
    
                // Get a byte array from the converted image.
                var imageBytes = GetBytes("image/tiff");
    
                // Save it for easy comparison.
                File.WriteAllBytes(@"C:\Sample2.png", imageBytes);
            }
    
            private static byte[] GetBytes(string mimeType)
            {
                var image = Image.FromFile(@"C:\Sample.tiff");
    
                var encoders = ImageCodecInfo.GetImageEncoders();
                var imageCodecInfo = encoders.FirstOrDefault(encoder => encoder.MimeType == mimeType);
    
                if (imageCodecInfo == null)
                {
                    return null;
                }
    
                using (var memoryStream = new MemoryStream())
                {
                    var imageEncoderParams = new EncoderParameters(1);
                    imageEncoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                    image.Save(memoryStream, imageCodecInfo, imageEncoderParams);
    
                    return memoryStream.GetBuffer();
                }
            }
    
            private static void SaveImage(string path, string mimeType)
            {
                var image = Image.FromFile(@"C:\Sample.tiff");
    
                var encoders = ImageCodecInfo.GetImageEncoders();
                var imageCodecInfo = encoders.FirstOrDefault(encoder => encoder.MimeType == mimeType);
    
                if (imageCodecInfo == null)
                {
                    return;
                }
    
                var imageEncoderParams = new EncoderParameters(1);
                imageEncoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                image.Save(path, imageCodecInfo, imageEncoderParams);
            }
        }
    }
