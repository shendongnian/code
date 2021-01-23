	public static class ImageExtensions
	{
		public static Image ImageFromRawBgraArray(this byte[] arr, int width, int height, PixelFormat pixelFormat)
		{
			var output = new Bitmap(width, height, pixelFormat);
			var rect = new Rectangle(0, 0, width, height);
			var bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);
            // Row by row copy
			var rowBytes = width * Image.GetPixelFormatSize(output.PixelFormat) / 8;
			var ptr = bmpData.Scan0;
			for (var i = 0; i < height; i++)
			{
				Marshal.Copy(arr, i * rowBytes, ptr, rowBytes);
				ptr += bmpData.Stride;
			}
			output.UnlockBits(bmpData);
			return output;
		}
	}
