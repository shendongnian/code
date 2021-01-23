    public static byte[] Array1DFromBitmap(Bitmap bmp){
    	if (bmp == null) throw new NullReferenceException("Bitmap is null");
    				
    	Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    	BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
    	IntPtr ptr = data.Scan0;
    				
    	//declare an array to hold the bytes of the bitmap
    	int numBytes = data.Stride * bmp.Height;
    	byte[] bytes = new byte[numBytes];
    
    	//copy the RGB values into the array
    	System.Runtime.InteropServices.Marshal.Copy(ptr, bytes, 0, numBytes);
    
    	bmp.UnlockBits(data);
    				
    	return bytes;			
    }
    
    public static Bitmap BitmapFromArray1D(byte[] bytes, int width, int height)
    {
    	Bitmap grayBmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
    	Rectangle grayRect = new Rectangle(0, 0, grayBmp.Width, grayBmp.Height);
    	BitmapData grayData = grayBmp.LockBits(grayRect, ImageLockMode.ReadWrite, grayBmp.PixelFormat);
    	IntPtr grayPtr = grayData.Scan0;
    				
    	int grayBytes = grayData.Stride * grayBmp.Height;
    	ColorPalette pal = grayBmp.Palette;
    				
    	for (int g = 0; g < 256; g++){
    		pal.Entries[g] = Color.FromArgb(g, g, g);
    	}
    				
    	grayBmp.Palette = pal;
    				
    	System.Runtime.InteropServices.Marshal.Copy(bytes, 0, grayPtr, grayBytes);
    				
    	grayBmp.UnlockBits(grayData);
    	return grayBmp;
    }
