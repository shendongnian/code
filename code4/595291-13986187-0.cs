	private static Point FindFirstColor(Color color)
	{
		int searchValue = color.ToArgb();
		using (Bitmap bmp = GetScreenShot())
		{
			for (int x = 0; x < bmp.Width; x++)
			{
				for (int y = 0; y < bmp.Height; y++)
				{
					if (searchValue.Equals(bmp.GetPixel(x, y).ToArgb()))
					{
						return new Point(x, y);
					}
				}
			}
		}
		return Point.Empty;
	}
