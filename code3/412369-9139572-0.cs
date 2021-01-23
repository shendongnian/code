	// tile size
	var x_scale = 150;
	var y_scale = 150;
	// load source bitmap
	using(var sourceBitmap = new Bitmap(@"F:\temp\Input.png"))
	{
		var image_width = sourceBitmap.Width;
		var image_height = sourceBitmap.Height;
		for(int x = 0; x < image_width - x_scale; x += x_scale)
		{
			for(int y = 0; y < image_height - y_scale; y += y_scale)
			{
				// select source area
				var sourceData = sourceBitmap.LockBits(
					new Rectangle(x, y, x_scale, y_scale),
					System.Drawing.Imaging.ImageLockMode.ReadOnly,
					sourceBitmap.PixelFormat);
				// get bitmap for selected area
				using(var tile = new Bitmap(
					sourceData.Width,
					sourceData.Height,
					sourceData.Stride,
					sourceData.PixelFormat,
					sourceData.Scan0))
				{
					// save it
					tile.Save(string.Format(@"F:\temp\tile-{0}x{1}.png", x, y));
				}
				// unlock area
				sourceBitmap.UnlockBits(sourceData);
			}
		}
	}
