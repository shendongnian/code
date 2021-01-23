	public byte[] imageToByteArray(Image imageIn)
	{
		Bitmap lbBMP = new Bitmap(imageIn);
		List<byte> lbBytes = new List<byte>();
		for(int liY = 0; liY < lbBMP.Height; liY++)
			for(int liX = 0; liX < lbBMP.Width; liX++)
			{
				Color lcCol = lbBMP.GetPixel(liX, liY);
				lbBytes.AddRange(new[] { lcCol.R, lcCol.G, lcCol.B });
			}
		return lbBytes.ToArray();
	}
