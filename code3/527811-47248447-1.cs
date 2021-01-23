	Bitmap GetBitmapFromSource(BitmapSource source) //, bool alphaTransparency
	{
        //convert image pixel format:
        var bs32 = new FormatConvertedBitmap(); //inherits from BitmapSource
        bs32.BeginInit();
        bs32.Source = source;
        bs32.DestinationFormat = System.Windows.Media.PixelFormats.Bgra32;
        bs32.EndInit();
        //source = bs32;
        //now convert it to Bitmap:
		Bitmap bmp = new Bitmap(bs32.PixelWidth, bs32.PixelHeight, PixelFormat.Format32bppArgb);
		BitmapData data = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), ImageLockMode.WriteOnly, bmp.PixelFormat);
		bs32.CopyPixels(System.Windows.Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
		bmp.UnlockBits(data);
		return bmp;
	}
