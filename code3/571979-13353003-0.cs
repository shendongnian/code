        public static Size ResizeImage(
           string fileName, 
           string targetFileName, 
           Size boundingSize, 
           string targetMimeType, 
           long quality)
        {
            ImageCodecInfo imageCodecInfo = 
                ImageCodecInfo
                   .GetImageEncoders()
                   .Single(i => i.MimeType == targetMimeType);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = 
                new EncoderParameter(Encoder.Quality, quality);
            using (FileStream fs = File.OpenRead(fileName))
            {
                Image img ;
                try
                {
                    img = Image.FromStream(fs, true, true);
                }
                catch (ArgumentException ex)
                {
                    throw new FileFormatException("cannot decode image",ex);
                } 
                using (img)
                {
                    double targetAspectRatio = 
                        ((double)boundingSize.Width) / boundingSize.Height;
                    double srcAspectRatio = ((double)img.Width) / img.Height;
                    int targetWidth = boundingSize.Width;
                    int targetHeight = boundingSize.Height;
                    if (srcAspectRatio > targetAspectRatio)
                    {
                        double h = targetWidth / srcAspectRatio;
                        targetHeight = Convert.ToInt32(Math.Round(h));
                    }
                    else
                    {
                        double w = targetHeight * srcAspectRatio;
                        targetWidth = Convert.ToInt32(Math.Round(w));
                    }
                    using (Image thumbNail = new Bitmap(targetWidth, targetHeight))
                    using (Graphics g = Graphics.FromImage(thumbNail))
                    {
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Rectangle rect = 
                            new Rectangle(0, 0, targetWidth, targetHeight);
                        g.DrawImage(img, rect);
                        thumbNail.Save(
                            targetFileName, imageCodecInfo, encoderParams);
                    }
                    return new Size(targetWidth, targetHeight);
                }
            }
        }
