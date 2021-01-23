    /// <summary>
    /// Convert Tiff image to another mime-type
    /// </summary>
    /// <param name="tiffImage">Source Tiff file</param>
    /// <param name="mimeType">Desired result mime-type</param>
    /// <returns>Converted image</returns>
    public Bitmap ConvertTiffToBitmap(Image tiffImage, string mimeType)
    {
    	var imageCodecInfo = ImageCodecInfo.GetImageEncoders().First(encoder => encoder.MimeType == MimeType.Tiff);
    
    	using (var memoryStream = new MemoryStream())
    	{
    		// Setting encode params
    		var imageEncoderParams = new EncoderParameters(1)
    		{
    			Param = {[0] = new EncoderParameter(Encoder.Quality, 100L)}
    		};
    
    		tiffImage.Save(memoryStream, imageCodecInfo, imageEncoderParams);
    
    		var converter = new ImageConverter();
    
    		// Reading stream data to new image
    		var tempTiffImage = (Image)converter.ConvertFrom(memoryStream.GetBuffer());
    
    		// Setting new result mime-type
    		imageCodecInfo = ImageCodecInfo.GetImageEncoders().First(encoder => encoder.MimeType == mimeType);
    		tempTiffImage?.Save(memoryStream, imageCodecInfo, imageEncoderParams);
    
    		return new Bitmap(Image.FromStream(memoryStream, true));
    	}
    }
    
    public static class MimeType
    {
    	public const string Bmp = "image/bmp";
    	public const string Gif = "image/gif";
    	public const string Jpeg = "image/jpeg";
    	public const string Png = "image/png";
    	public const string Tiff = "image/tiff";
    }
