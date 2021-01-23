    private Image ScaleFreeHeight(string imagePath, int newWidth)
    {
    	var byteArray = new StreamReader(imagePath).BaseStream;        
    	var image = Image.FromStream(byteArray);
    	var newHeight2 = Convert.ToInt32(newWidth * (1.0000000 * image.Height / image.Width));
    	var thumbnail = new Bitmap(newWidth, newHeight2);
    	var graphic = Graphics.FromImage(thumbnail);
    	graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
    	graphic.SmoothingMode = SmoothingMode.HighQuality;
    	graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
    	graphic.CompositingQuality = CompositingQuality.HighQuality
    
    	graphic.DrawImage(image, 0, 0, newWidth, newHeight2);
    
    	return thumbnail;
    }
