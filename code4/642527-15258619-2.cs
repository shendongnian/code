    System.Drawing.Bitmap bitmap = BitmapSourceToBitmap((BitmapSource)YourImageControl.Source);
    bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
	public static System.Drawing.Bitmap BitmapSourceToBitmap(BitmapSource bitmapsource)
	{
		System.Drawing.Bitmap bitmap;
		using (MemoryStream outStream = new MemoryStream())
		{
			BitmapEncoder enc = new BmpBitmapEncoder();
			enc.Frames.Add(BitmapFrame.Create(bitmapsource));
			enc.Save(outStream);
			bitmap = new System.Drawing.Bitmap(outStream);
		}
		return bitmap;
	}
