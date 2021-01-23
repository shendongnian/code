    private string BitmapToByte(Image image)
    {
    	Bitmap sizedImage = new Bitmap(image, new Size(400, 400));
    
    	byte[] bytes;
    	using(MemoryStream ms = new MemoryStream())
    	{
    		sizedImage.Save(ms, ImageFormat.Jpeg);
    		bytes = ms.ToArray();
    	}
    	string str = Convert.ToBase64String(bytes);
    	return str;
    }
