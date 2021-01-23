    try
    {
    	Image image = Image.FromFile("test.jpg");
    	Bitmap bmp = new Bitmap(200, 200, PixelFormat.Format24bppRgb);
    	bmp.SetResolution(80, 60);
    
    	Graphics gfx = Graphics.FromImage(bmp);
    	gfx.SmoothingMode = SmoothingMode.AntiAlias;
    	gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
    	gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
    	gfx.DrawImage(image, new Rectangle(0, 0, 200, 200), 10, 10, 200, 200, GraphicsUnit.Pixel);
    	
    	//Need to write the file to memory then save it
    	MemorySteam ms = new MemoryStream();
    	bmp.Save(ms, image.RawFormat); 
    	byte[] buffer = ms.GetBuffer();
    	
    	var stream = new MemorySteam((buffer), 0, buffer.Length); 
    	var croppedImage = SD.Image.FromStream(steam, true);
    	croppedImage.Save("/your/path/", croppedImage.RawFormat);
    
    	// Dispose to free up resources
    	image.Dispose();
    	bmp.Dispose();
    	gfx.Dispose();
    	stream.Dispose();
    	croppedImage.Dispose();
    	
    }
    catch (Exception ex)
    {
    	MessageBox.Show(ex.Message);
    }
