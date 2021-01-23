    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    
    namespace ImageResize
    {
        internal class Program
        {
            private static readonly string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    
            private static void Main()
            {
                var strFiles = Directory.GetFiles(directory, "*.jpg");
    
                //Using parallel processing for performance
                Parallel.ForEach(strFiles, strFile =>
                                               {
                                                   using (var image = Image.FromFile(strFile, true))
                                                   {
                                                       var exif = image.PropertyItems;
                                                       var b = directory + "\\" + Path.GetFileNameWithoutExtension(strFile);
                                                       ResizeImage(image, 800, b + "_FULL.jpg", exif);
                                                       ResizeImage(image, 200, b + "_THUMB.jpg", exif);
                                                   }
                                                   File.Delete(strFile);
                                               });
            }
    
            private static void ResizeImage(Image theImage, int newSize, string savePath, IEnumerable<PropertyItem> propertyItems)
            {
                try
                {
                    int width;
                    int height;
                    CalculateNewRatio(theImage.Width, theImage.Height, newSize, out width, out height);
                    using (var b = new Bitmap(width, height))
                    {
                        using (var g = Graphics.FromImage(b))
                        {
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            g.DrawImage(theImage, new Rectangle(0, 0, width, height));
    
                            //Using FileStream to avoid lock issues because of the parallel processing
                            using (var stream = new FileStream(directory + "\\Watermark.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                using (var overLay = Image.FromStream(stream))
                                {
                                    stream.Close();
                                    int newWidth;
                                    int newHeight;
                                    CalculateNewRatio(overLay.Width, overLay.Height, height > width ? width : newSize, out newWidth, out newHeight);
                                    var x = (b.Width - newWidth) / 2;
                                    var y = (b.Height - newHeight) / 2;
                                    g.DrawImage(overLay, new Rectangle(x, y, newWidth, newHeight));
                                }
                            }
    
                            var qualityParam = new EncoderParameter(Encoder.Quality, 80L);
                            var codecs = ImageCodecInfo.GetImageEncoders();
                            var jpegCodec = codecs.FirstOrDefault(t => t.MimeType == "image/jpeg");
                            var encoderParams = new EncoderParameters(1);
                            encoderParams.Param[0] = qualityParam;
                            foreach (var item in propertyItems)
                            {
                                b.SetPropertyItem(item);
                            }
                            b.Save(savePath, jpegCodec, encoderParams);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
    
            private static void CalculateNewRatio(int width, int height, int desiredSize, out int newWidth, out int newHeight)
            {
                if ((width >= height && width > desiredSize) || (width <= height && height > desiredSize))
                {
                    if (width > height)
                    {
                        newWidth = desiredSize;
                        newHeight = height*newWidth/width;
                    }
                    else if (width < height)
                    {
                        newHeight = desiredSize;
                        newWidth = width*newHeight/height;
                    }
                    else
                    {
                        newWidth = desiredSize;
                        newHeight = desiredSize;
                    }
                }
                else
                {
                    newWidth = width;
                    newHeight = height;
                }
            }
        }
    }
