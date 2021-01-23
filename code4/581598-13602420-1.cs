	Bitmap bmp = new Bitmap("c:\\fakePhoto.jpg");
	// Lock the bitmap's bits.  
	Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
	System.Drawing.Imaging.BitmapData bmpData =	bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
	// Get the address of the first line.
	IntPtr ptr = bmpData.Scan0;
	// Declare an array to hold the bytes of the bitmap. 
	int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
	byte[] rgbValues = new byte[bytes];
	// Copy the RGB values into the array.
	System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
