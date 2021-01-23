    using ImageProcessor;
    using ImageProcessor.Imaging;
    using System.Drawing;
    using System.IO;
    public static byte[] ResizeAndCrop(byte[] image, int width, int height)
        {
            using (var ms = new MemoryStream())
            {
                using (var imgf = new ImageFactory(true))
                    imgf
                        .Load(image)
                        .Resize(new ResizeLayer(new Size(width, height), ResizeMode.Crop))
                        .Save(ms);
                return ms.ToArray();
            }
        }
