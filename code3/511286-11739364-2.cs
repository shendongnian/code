	var bitmap = new Bitmap(args.Width, args.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
	var data = bitmap.LockBits(
    	new Rectangle(0, 0, args.Width, args.Height),
		System.Drawing.Imaging.ImageLockMode.WriteOnly,
		System.Drawing.Imaging.PixelFormat.Format24bppRgb);
	if(data.Stride == args.Stride)
	{
		Marshal.Copy(data.Buffer, 0, data.Scan0, args.Stride * args.Height);
	}
	else
	{
		int arrayOffset = 0;
		int imageOffset = 0;
		for(int y = 0; y < args.Height; ++y)
		{
			Marshal.Copy(data.Buffer, arrayOffset, (IntPtr)(((long)data.Scan0) + imageOffset), data.Stride);
			arrayOffset += args.Stride;
			imageOffset += data.Stride;
		}
	}
	bitmap.UnlockBits(data);
