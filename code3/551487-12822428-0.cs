        public Bitmap ResizedImage(Stream imageStream, int newWidth)
        {
            Image image = Image.FromStream(imageStream);
            int newwidthimg = image.Size.Width;
            int newheightimg = image.Size.Height;
            if (newWidth <= image.Size.Width)
            {
                newwidthimg = newWidth;
                float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                newheightimg = Convert.ToInt32(newwidthimg / AspectRatio);
            }
            Bitmap thumbnailBitmap = new Bitmap(newwidthimg, newheightimg);
            using (Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap))
            {
                thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newwidthimg, newheightimg);
                thumbnailGraph.DrawImage(image, imageRectangle);
            }
            return thumbnailBitmap;
