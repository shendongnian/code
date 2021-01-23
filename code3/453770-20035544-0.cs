    bool SaveCroppedImage(Image image, int maxWidth, int maxHeight, string filePath)
    {
        ImageCodecInfo jpgInfo = ImageCodecInfo.GetImageEncoders().Where(codecInfo => codecInfo.MimeType == "image/jpeg").First();
        Image finalImage = image;
        System.Drawing.Bitmap bitmap = null;
        try
        {
            int left = 0;
            int top = 0;
            int srcWidth = maxWidth;
            int srcHeight = maxHeight;
            bitmap = new System.Drawing.Bitmap(maxWidth, maxHeight);
            double croppedHeightToWidth = (double)maxHeight / maxWidth;
            double croppedWidthToHeight = (double)maxWidth / maxHeight;
            if (image.Width > image.Height)
            {
                srcWidth = (int)(Math.Round(image.Height * croppedWidthToHeight));
                if (srcWidth < image.Width)
                {
                    srcHeight = image.Height;
                    left = (image.Width - srcWidth) / 2;
                }
                else
                {
                    srcHeight = (int)Math.Round(image.Height * ((double)image.Width / srcWidth));
                    srcWidth = image.Width;
                    top = (image.Height - srcHeight) / 2;
                }
            }
            else
            {
                srcHeight = (int)(Math.Round(image.Width * croppedHeightToWidth));
                if (srcHeight < image.Height)
                {
                    srcWidth = image.Width;
                    top = (image.Height - srcHeight) / 2;
                }
                else
                {
                    srcWidth = (int)Math.Round(image.Width * ((double)image.Height / srcHeight));
                    srcHeight = image.Height;
                    left = (image.Width - srcWidth) / 2;
                }
            }
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(left, top, srcWidth, srcHeight), GraphicsUnit.Pixel);
            }
            finalImage = bitmap;
        }
        catch { }
        try
        {
            using (EncoderParameters encParams = new EncoderParameters(1))
            {
                encParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                //quality should be in the range [0..100] .. 100 for max, 0 for min (0 best compression)
                finalImage.Save(filePath, jpgInfo, encParams);
                return true;
            }
        }
        catch { }
        if (bitmap != null)
        {
            bitmap.Dispose();
        }
        return false;
    }
