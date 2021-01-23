	static Color dominantColor(Bitmap img)
	{
		Hashtable colorCount = new Hashtable();
		int maxCount = 0;
		Color dominantColor = Color.White;
		for (int i = 0; i < img.Width; i++)
		{
			for (int j = 0; j < img.Height; j++)
			{
				var color = img.GetPixel(i, j);
				if (color.A == 0)
					continue;
				// ignore white
				if (color.Equals(Color.White))
					continue;
				if (colorCount[color] != null)
					colorCount[color] = (int)colorCount[color] + 1;
				else
					colorCount.Add(color, 0);
				// keep track of the color that appears the most times
				if ((int)colorCount[color] > maxCount)
				{
					maxCount = (int)colorCount[color];
					dominantColor = color;
				}
			}
		}
		return dominantColor;
	}
