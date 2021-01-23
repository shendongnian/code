	// Generate dots in random cells and show image
	for (int i = 0; i < bmpData.Height; i++)
	{
		for (int j = 0; j < bmpData.Width; j += 8)
		{
			rgbValues[i * bmpData.Stride + j / 8] = (byte)r.Next(0, 256);
		}
	}
