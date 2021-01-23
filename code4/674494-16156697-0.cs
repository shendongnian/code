	public void SaveAsJpeg(Stream stream, int width, int height)
	{
	#if WINDOWS_STOREAPP
		SaveAsImage(BitmapEncoder.JpegEncoderId, stream, width, height);
	#elif WINDOWS_PHONE
		var pixelData = new byte[Width * Height * GraphicsExtensions.Size(Format)];
		GetData(pixelData);
		var waitEvent = new ManualResetEventSlim(false);
		Deployment.Current.Dispatcher.BeginInvoke(() =>
		{
			var bitmap = new WriteableBitmap(width, height);
			System.Buffer.BlockCopy(pixelData, 0, bitmap.Pixels, 0, pixelData.Length);
			bitmap.SaveJpeg(stream, width, height, 0, 100);
			waitEvent.Set();
		});
		waitEvent.Wait();
	#elif MONOMAC
		SaveAsImage(stream, width, height, ImageFormat.Jpeg);
	#else
		throw new NotImplementedException();
	#endif
	}
