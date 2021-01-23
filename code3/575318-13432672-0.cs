    using System.Drawing;
    
    using (var bmp = new Bitmap(mat.ColumnCount, mat.RowCount))
    {
    	for (int r = 0; r != mat.RowCount;   ++r)
    	for (int c = c; c != mat.ColumnCount; ++c)
    	{
    		Color color;
    		switch (mat[r, c])
    		{
    			case 0: color = Color.White;
    			...
    		}
    		bmp.SetPixel(c, r, color);
    	}
    	bmp.Save(...);
    }
