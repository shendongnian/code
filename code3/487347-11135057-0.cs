     Bitmap BytesToBitmap (byte[] bmpBytes, Size imageSize)
    {
    	Bitmap bmp = new Bitmap (imageSize.Width, imageSize.Height);
    
    	BitmapData bData  = bmp.LockBits (new Rectangle (New Point(0,0), bmp.Size),
    		ImageLockMode.WriteOnly,
    		PixelFormat.Format24bppRgb);
    
    	// Copy the bytes to the bitmap object
    	Marshal.Copy (bmpBytes, 0, bData.Scan0, bmpBytes.Length);
    	bmp.UnlockBits(bData);
    	return bmp;
    }
