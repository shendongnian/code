    private Bitmap ScaleImage(Image oldImage)
    {
        double resizeFactor = 1;
        if (oldImage.Width > 150 || oldImage.Height > 150)
        {
            double widthFactor = Convert.ToDouble(oldImage.Width) / 150;
            double heightFactor = Convert.ToDouble(oldImage.Height) / 150;
            resizeFactor = Math.Max(widthFactor, heightFactor);
        }
        int width = Convert.ToInt32(oldImage.Width / resizeFactor);
        int height = Convert.ToInt32(oldImage.Height / resizeFactor);
        Bitmap newImage = new Bitmap(width, height);
        Graphics g = Graphics.FromImage(newImage);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.DrawImage(oldImage, 0, 0, newImage.Width, newImage.Height);
        return newImage;
    }
