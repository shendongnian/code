	// Luminance vector for linear RGB
	const float rwgt = 0.3086f;
	const float gwgt = 0.6094f;
	const float bwgt = 0.0820f;
	private ImageAttributes imageAttributes = new ImageAttributes();
	private ColorMatrix colorMatrix = new ColorMatrix();
	private float saturation = 1.0f;
	private float brightness = 1.0f;
	protected override void OnPaint(object sender, PaintEventArgs e)
	{
		base.OnPaint(sender, e);
		
		e.Graphics.DrawImage(_bitmap, BitmapRect, BitmapRect.X, BitmapRect.Y, BitmapRect.Width, BitmapRect.Height, GraphicsUnit.Pixel, imageAttributes);
	}
	private void saturationTrackBar_ValueChanged(object sender, EventArgs e)
	{
		saturation = 1f - (saturationTrackBar.Value / 100f);
		float baseSat = 1.0f - saturation;
		colorMatrix[0, 0] = baseSat * rwgt + saturation;
		colorMatrix[0, 1] = baseSat * rwgt;
		colorMatrix[0, 2] = baseSat * rwgt;
		colorMatrix[1, 0] = baseSat * gwgt;
		colorMatrix[1, 1] = baseSat * gwgt + saturation;
		colorMatrix[1, 2] = baseSat * gwgt;
		colorMatrix[2, 0] = baseSat * bwgt;
		colorMatrix[2, 1] = baseSat * bwgt;
		colorMatrix[2, 2] = baseSat * bwgt + saturation;
		imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		Invalidate();
	}
	private void brightnessTrackBar_ValueChanged(object sender, EventArgs e)
	{
		brightness = 1f + (brightnessTrackBar.Value / 100f);
		float adjustedBrightness = brightness - 1f;
		colorMatrix[4, 0] = adjustedBrightness;
		colorMatrix[4, 1] = adjustedBrightness;
		colorMatrix[4, 2] = adjustedBrightness;
		imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		Invalidate();
	}
