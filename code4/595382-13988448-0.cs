    // 1x1 transparent GIF
    private readonly byte[] GifData = {
        0x47, 0x49, 0x46, 0x38, 0x39, 0x61,
        0x01, 0x00, 0x01, 0x00, 0x80, 0xff,
        0x00, 0xff, 0xff, 0xff, 0x00, 0x00,
        0x00, 0x2c, 0x00, 0x00, 0x00, 0x00,
        0x01, 0x00, 0x01, 0x00, 0x00, 0x02,
        0x02, 0x44, 0x01, 0x00, 0x3b
    };
    
    public void ProcessRequest(HttpContext context)
    {
    	// render direct
    	context.Response.BufferOutput = false;
    
    	bool fFail = true;
    	
    	try
    	{
    	  if (!string.IsNullOrEmpty(context.Request.QueryString["img"]))
    	  {
    		string fileName = context.Request.QueryString["img"];		  
    
    		using( var inputImage = new Bitmap(fileName))
    		{	
    		    // create the thubnail
    			FinalImage = CreateThubNain();		    
    
                // send it to browser
    			FinalImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);			
    			// flag tha all ends up well
    			fFail = false;
    		}          
    	  }
    	}
    	catch(Exception x)
    	{
    		// log the error
    		Debug.Fail("Check why is fail - error:" + x.ToString());
    	}
    
    	if(fFail)
    	{
    		// send something anyway
    		context.Response.ContentType = "image/gif";
    		context.Response.OutputStream.Write(GifData, 0, GifData.Length);
    	}
    	else
    	{
    		// this is a header that you can get when you read the image
    		context.Response.ContentType = "image/jpeg";
    
    		// the size of the image, saves from load the image, and send it here
    		// context.Response.AddHeader("Content-Length", imageData.Length.ToString());
    
    		// cache the image - 24h example
    		context.Response.Cache.SetExpires(DateTime.Now.AddHours(24));
    		context.Response.Cache.SetMaxAge(new TimeSpan(24, 0, 0));	
    	}
    }
        
