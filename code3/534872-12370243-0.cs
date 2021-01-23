    public static void SaveJpeg(string path, Image image, int quality)
    {
    	//ensure the quality is within the correct range
    	if ((quality < 0) || (quality > 100))
    	{
    		//create the error message
    		string error = string.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", quality);
    		//throw a helpful exception
    		throw new ArgumentOutOfRangeException(error);
    	}
    
    	//create an encoder parameter for the image quality
    	EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
    	//get the jpeg codec
    	ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
    
    	//create a collection of all parameters that we will pass to the encoder
    	EncoderParameters encoderParams = new EncoderParameters(1);
    	//set the quality parameter for the codec
    	encoderParams.Param[0] = qualityParam;
    	//save the image using the codec and the parameters
    	image.Save(path, jpegCodec, encoderParams);
    }
