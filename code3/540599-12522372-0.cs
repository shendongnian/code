	var bmp = (Bitmap)Bitmap.FromFile("myfile.tif");
	// ******* Begin copying your imageToByteArray method
	// Lock the bitmap's bits.  
	Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
	BitmapData bmpData = bmp.LockBits(
		rect,
		ImageLockMode.ReadWrite,
		bmp.PixelFormat);
	// Get the address of the first line.
	IntPtr ptr = bmpData.Scan0;
	// Declare an array to hold the bytes of the bitmap. 
	int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
	byte[] imageData = new byte[bytes];
	// Copy the RGB values into the array.
	System.Runtime.InteropServices.Marshal.Copy(ptr, imageData, 0, bytes);
	// Unlock the bits.
	bmp.UnlockBits(bmpData);
	// ******* End copying your imageToByteArray method
	// Now loop through each pixel...  The byte array contains extra bytes
	// used for padding so we can't just loop through every byte in the array.
	// This is done by using the Stride property on bmpData.
	for (int y = 0; y < bmpData.Height; y++)
	{
		for (int x = 0; x < bmpData.Width; x++)
		{
			var offset = (y * bmpData.Stride) + x;
			// The byte in the image array gives the offset into the palette
			var paletteIndex = imageData[offset];
			// Given the offset, find the matching color in the palette
			var color = bmp.Palette.Entries[offset];
			// Look at the color value here...
		}
	}
