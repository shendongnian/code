    using(var bmp = new Bitmap("C:\\temp\\source.jpg"))
    {
    	for (int x = 0; x < bmp.Width; x++)
    	for (int y = 0; y < bmp.Height; y++)
    	{
    		var c = bmp.GetPixel(x, y);
    		bmp.SetPixel(x, y, Color.FromArgb(c.A, 0, c.G, c.B));
    	}
    	bmp.Save("C:\\temp\\target.jpg", ImageFormat.Jpeg);
    }
