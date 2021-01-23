	System.Drawing.Imaging.BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format48bppRgb);
	unsafe
	{
		srs.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
		for (var row = 0; row < srs.PixelHeight; row++)
		{
			for (var col = 0; col < srs.PixelWidth; col++)
			{
				byte* pixel = (byte*)data.Scan0 + (row * data.Stride) + (col * 6);
				
				var val1 = pixel[1];
				var val3 = pixel[3];
				var val2 = pixel[2];
				var val4 = pixel[4];
				var val5 = pixel[5];
				var val0 = pixel[0];
				//// 0, 1: B, 2:3: G, 4, 5: R
				pixel[5] = val1;
				pixel[4] = val0;
				pixel[0] = val4;
				pixel[1] = val5;
			}
		}
	}
	bmp.UnlockBits(data);
