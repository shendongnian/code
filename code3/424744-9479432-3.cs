		// Lock the bitmap's bits.  
		Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
		System.Drawing.Imaging.BitmapData bmpData = 
			bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
			bmp.PixelFormat);
			  
		// Get the address of the first line.
	    IntPtr ptr = bmpData.Scan0;
		// Declare an array to hold the bytes of the bitmap.
		// This code is specific to a bitmap with 24 bits per pixels.
		int bytes = bmp.Width * bmp.Height * 3;
		unsafe
		{
			byte* rgbValues = (byte*)ptr;
			// Set every red value to 255.  
			for (int counter = 2; counter < bytes counter+=3)
				rgbValues[counter] = 255;
        } 
		
		// Unlock the bits.
		bmp.UnlockBits(bmpData);
