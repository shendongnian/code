	unsafe private static void TestBMP()
	{
		Bitmap bmp = new Bitmap("d:\\24bits.bmp");
		// Ensure that format is Format24bppRgb.
		Console.WriteLine(bmp.PixelFormat);
		Bitmap copyBmp = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
		// Copy all pixels of initial image for verification.
		int pixels = bmp.Height * bmp.Width;
		Color[,] allPixels = new Color[bmp.Height, bmp.Width];
		for (int i = 0; i < bmp.Height; i++)
			for (int j = 0; j < bmp.Width; j++)
				allPixels[i, j] = bmp.GetPixel(j, i);
		// Lock the bitmap's bits.  
		Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
		System.Drawing.Imaging.BitmapData bmpData =
			bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
			bmp.PixelFormat);
		IntPtr ptr = bmpData.Scan0;
		// Declare an array to hold the bytes of the bitmap. 
		int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
		byte* stream = (byte*)ptr;
		for (int y = 0; y < bmp.Height; y++)
			for (int x = 0; x < bmp.Width; x++)
			{
				int bitIndex = y * bmpData.Stride + x * 3;
				byte r = stream[bitIndex + 2];
				byte g = stream[bitIndex + 1];
				byte b = stream[bitIndex];
				Color c = allPixels[y, x];
				if (r != c.R || g != c.G || b != c.B)
				{
					Console.WriteLine("This should never appear");
				}
				copyBmp.SetPixel(x, y, Color.FromArgb(255, r, g, b));
			}
		// Save new image. It should be the same as initial one.
		copyBmp.Save("d:\\24bits_1.bmp");
	}
