    public static Bitmap ResizeImage(Image image, Size size)
    {            
        Bitmap result = new Bitmap(size.Width, size.Height);
                            
        using (Graphics graphics = Graphics.FromImage(result))
        {                
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(image, 0, 0, result.Width, result.Height);
        }
    
        return result;
    }
