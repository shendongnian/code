    private Bitmap ResizeImage(Image image, int width, int height)
    {
    	Bitmap result = new Bitmap(width, height);
    	result.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    	using (Graphics graphics = Graphics.FromImage(result))
    	{
    		graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    		graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    		graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    
    		graphics.DrawImage(image, 0, 0, result.Width, result.Height);
    	}
    	return result;
    }
