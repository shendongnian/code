    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading;
    namespace Simple {
        public static class ThumbnailCreator {
            private static readonly object _lock = new object();
            public static Bitmap createThumbnail(Stream source, Int32 width, Int32 height) {
                Monitor.Enter(_lock);
                Bitmap output = null;
                try {
                    using (Bitmap workingBitmap = new Bitmap(source)) {
                        // Determine scale based on requested height/width (this preserves aspect ratio)
                        Decimal scale;
                        if (((Decimal)workingBitmap.Width / (Decimal)width) > ((Decimal)workingBitmap.Height / (Decimal)height)) {
                            scale = (Decimal)workingBitmap.Width / (Decimal)width;
                        }
                        else {
                            scale = (Decimal)workingBitmap.Height / (Decimal)height;
                        }
                        // Calculate new height/width
                        Int32 newHeight = (Int32)((Decimal)workingBitmap.Height / scale);
                        Int32 newWidth = (Int32)((Decimal)workingBitmap.Width / scale);
                        // Create blank BitMap of appropriate size
                        output = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
                        // Create Graphics surface
                        using (Graphics g = Graphics.FromImage(output)) {
                            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            Rectangle destRectangle = new Rectangle(0, 0, newWidth, newHeight);
                            // Use Graphics surface to draw resized BitMap to blank BitMap
                            g.DrawImage(workingBitmap, destRectangle, 0, 0, workingBitmap.Width, workingBitmap.Height, GraphicsUnit.Pixel);
                        }
                    }
                }
                catch {
                    output = null;
                }
                finally {
                    Monitor.Exit(_lock);
                }
                return output;
            }
        }
    }
