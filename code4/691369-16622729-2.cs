	// Create 8 bit per pixel bitmap
	var bitmap = new Bitmap(512, 512, PixelFormat.Format8bppIndexed);
	
	// Set grayscale color palette
	var colorPalette = bitmap.Palette;
	var colorEntries = colorPalette.Entries;
	
	for ( int i = 0; i < 256; i++ )
	{
		colorEntries[i] = Color.FromArgb(i, i, i);
	}
    // Apply changes to color pallete
    bitmap.Palette = colorPalette;
	
	// Retrieve bitmap data for efficient writes
	var bitmapData = bitmap.LockBits(Rectangle.FromLTRB(0, 0, 512, 512), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
	
	// Allocate array to store intermediate pixel data
	byte[] colorData = new byte[bitmapData.Stride * bitmapData.Height]; // 1 byte per pixel since it is 8bppIndexed format
	
	for (int i = 0; integers.Length; i++)
	{
		int line = i / 512;
		int position = i % 512;
		
		colorData[line * bitmapData.Stride + position] = (byte)integers[i]; // color values from file
	}
	
	// Copy computed pixel data to BitmapData
	Marshal.Copy(colorData, 0, bitmapData.Scan0, colorData.Length);
	
	bitmap.UnlockBits(bitmapData);
	
	bitmap.Save("D:\\test.bmp");
	
