        public static Image Resize(
            Image srcImage, 
            int newWidth, 
            int maxHeight,
            int dpi = 72)
        {
            if(srcImage.Width<=newWidth)
            {
                newWidth = srcImage.Width;
            }
            var newHeight = srcImage.Height * newWidth / srcImage.Width;
            if (newHeight > maxHeight)
            {
                newWidth = srcImage.Width * maxHeight / srcImage.Height;
                newHeight = maxHeight;
            }
            
            var newImage = new Bitmap(newWidth, newHeight);
            newImage.SetResolution(dpi, dpi);
            using (var gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
            }
            return newImage;
        }
