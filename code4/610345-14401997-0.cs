	public static void Resize(string input, string output)
	{
		using (var inputStream = File.OpenRead(input))
		{
			var photoDecoder = BitmapDecoder.Create(inputStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
			
			var frame = photoDecoder.Frames[0];
			using (var ouputStream = File.Create(output))
			{
				var targetEncoder = new PngBitmapEncoder();
				targetEncoder.Frames.Add(frame);
				targetEncoder.Save(ouputStream);
			}
		}    
	}
