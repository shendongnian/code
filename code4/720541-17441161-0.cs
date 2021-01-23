	public static Image Resize(Image originalImage, int w, int h)
	{
		//Original Image attributes
		int originalWidth = originalImage.Width;
		int originalHeight = originalImage.Height;
		// Figure out the ratio
		double ratioX = (double)w / (double)originalWidth;
		double ratioY = (double)h / (double)originalHeight;
		// use whichever multiplier is smaller
		double ratio = ratioX < ratioY ? ratioX : ratioY;
		// now we can get the new height and width
		int newHeight = Convert.ToInt32(originalHeight * ratio);
		int newWidth = Convert.ToInt32(originalWidth * ratio);
		Image thumbnail = new Bitmap(newWidth, newHeight);
		Graphics graphic = Graphics.FromImage(thumbnail);
		graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphic.SmoothingMode = SmoothingMode.HighQuality;
		graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		graphic.CompositingQuality = CompositingQuality.HighQuality;
		graphic.Clear(Color.Transparent);
		graphic.DrawImage(originalImage, 0, 0, newWidth, newHeight);
		return thumbnail;
	}
