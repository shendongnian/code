    private static Bitmap _resize(Image image, int width, int height)
    {
        Bitmap newImage = new Bitmap(width, height);
        //this is what allows the quality to stay the same when reducing image dimensions
        newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        using (Graphics gr = Graphics.FromImage(newImage))
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gr.DrawImage(image, new Rectangle(0, 0, width, height));
        }
        return newImage;
    }
