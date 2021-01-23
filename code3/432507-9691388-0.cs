    		Bitmap bmp = new Bitmap(@"C:\original.jpg");
			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			BitmapData rawOriginal = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			int origByteCount = rawOriginal.Stride * rawOriginal.Height;
			byte[] origBytes = new Byte[origByteCount];
			Marshal.Copy(rawOriginal.Scan0, origBytes, 0, origByteCount);
			
			//I want to crop a 100x100 section starting at 15, 15.
			int startX = 15;
			int startY = 15;
			int width = 100;
			int height = 100;
			int BPP = 4;		//4 Bpp = 32 bits, 3 = 24, etc.
			byte[] croppedBytes = new Byte[width * height * BPP];
			//Iterate the selected area of the original image, and the full area of the new image
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width * BPP; j += BPP)
				{
					int origIndex = (startX * rawOriginal.Stride) + (i * rawOriginal.Stride) + (startY * BPP) + (j);
					int croppedIndex = (i * width * BPP) + (j);
					//copy data: once for each channel
					for (int k = 0; k < BPP; k++)
					{
						croppedBytes[croppedIndex + k] = origBytes[origIndex + k];
					}
				}
			}
			//copy new data into a bitmap
			Bitmap croppedBitmap = new Bitmap(width, height);
			BitmapData croppedData = croppedBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			Marshal.Copy(croppedBytes, 0, croppedData.Scan0, croppedBytes.Length);
			
			bmp.UnlockBits(rawOriginal);
			croppedBitmap.UnlockBits(croppedData);
			croppedBitmap.Save(@"C:\test.bmp");
