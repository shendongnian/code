    public static class VisualToImg
	{
		static VisualToImg()
		{
			DPI = 96;
			PixelFormat = PixelFormats.Default;
		}
		public enum eImageFormat
		{ Bitmap, Png, Gif, Jpeg, Tiff, Wmp }
		static public bool SaveAs(FrameworkElement element, String filePath,
			eImageFormat imageFormat)
		{
			switch (imageFormat)
			{
				case eImageFormat.Bitmap:
					return SaveUsingEncoder(element, filePath, new BmpBitmapEncoder());
				case eImageFormat.Gif:
					return SaveUsingEncoder(element, filePath, new GifBitmapEncoder());
				case eImageFormat.Jpeg:
					return SaveUsingEncoder(element, filePath, new JpegBitmapEncoder());
				case eImageFormat.Png:
					return SaveUsingEncoder(element, filePath, new PngBitmapEncoder());
				case eImageFormat.Tiff:
					return SaveUsingEncoder(element, filePath, new TiffBitmapEncoder());
				case eImageFormat.Wmp:
					return SaveUsingEncoder(element, filePath, new WmpBitmapEncoder());
			}
			return false;
		}
		static public double DPI
		{ get; set; }
		static public PixelFormat PixelFormat
		{ get; set; }
		static private bool SaveUsingEncoder(FrameworkElement visual, string filePath,
			BitmapEncoder encoder)
		{
			try
			{
				RenderTargetBitmap bmp = new RenderTargetBitmap((int)visual.ActualWidth,
					(int)visual.ActualHeight, DPI, DPI, PixelFormat);
				bmp.Render(visual);
				encoder.Frames.Add(BitmapFrame.Create(bmp));
				using (var stream = File.Create(filePath))
				{ encoder.Save(stream); }
				return true;
			}
			catch (Exception)
			{ return false; }
		}
	}
