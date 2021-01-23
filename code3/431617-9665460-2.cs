    private int[,] ConvertToInt(string[,] matrix)
    {
     int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
     for (int i = 0; i < result.GetLength(0); ++i)
     {
      for (int j = 0; j < result.GetLength(1); ++j)
      {
       int value = 0;
       if (Int32.TryParse(matrix[i, j], System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
        result[i, j] = value;
      }
     }
    
     return result;
    }
