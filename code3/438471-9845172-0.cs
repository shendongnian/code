	public static float[,] ConvertToGrayScale2(this Bitmap bm)
	{
		var data = new float[bm.Width, bm.Height];
		for (var i = 0; i < bm.Width; i++)
		{
			for (int x = 0; x < bm.Height; x++)
			{
				var oc = bm.GetPixel(i, x);
                                // casting to int here - you can just use a 2d array of ints
				data[i, x] = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
			}
		}
		return data;
	}
