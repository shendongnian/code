    public void ResizeImage(Stream input, Stream output, int newWidth, int maxHeight)
    {
        using (var srcImage = Image.FromStream(input))
        {
            int newHeight = srcImage.Height * newWidth / srcImage.Width;
            if (newHeight > maxHeight)
            {
                newWidth = srcImage.Width * maxHeight / srcImage.Height;
                newHeight = maxHeight;
            }
            using (var newImage = new Bitmap(newWidth, newHeight))
            using (var gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                newImage.Save(output, ImageFormat.Jpeg);
            }
        }
    }
