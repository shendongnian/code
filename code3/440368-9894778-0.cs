    public static int [,] To2DArray(this IEnumerable<int> numbers, int rows, int cols)
    {
      //Assume numbers.Count == rows * cols
      int [,] matrix = new int [rows, cols];
      int row = 0;
      int col = 0;
      foreach (int n in numbers)
      {
        matrix[row, col] = n;
        col++;
        if (col == cols)
        {
          row++;
          col = 0;
        }
      }
      return matrix;
    }
