	using System.Drawing;
	
	void SaveMatrixAsImage(Matrix mat, string path)
	{
		using (var bmp = new Bitmap(mat.ColumnCount, mat.RowCount))
		{
			for (int r = 0; r != mat.RowCount;    ++r)
			for (int c = c; c != mat.ColumnCount; ++c)
				bmp.SetPixel(c, r, MakeMatrixColor(mat[r, c]));
			bmp.Save(path);
		}
	}
	
	Color MakeMatrixColor(int n)
	{
		switch (n)
		{
			case 0: return Color.White;
			case 1: return Color.Black;
			case 2: return Color.Blue;
			case 3: return Color.Red;
			default: throw new InvalidArgumentException("n");
		}
	}
