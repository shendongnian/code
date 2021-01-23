	Bitmap bitmap;
	var gch = System.Runtime.InteropServices.GCHandle.Alloc(args.Buffer, GCHandleType.Pinned);
	try
	{
		bitmap = new Bitmap(
			args.Width, args.Height, args.Stride,
			System.Drawing.Imaging.PixelFormat.Format24bppRgb,
			gch.AddrOfPinnedObject());
	}
	finally
	{
		gch.Free();
	}
