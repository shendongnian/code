    public static class MatrixExtensions
    {
      /// <summary>
      /// Returns the row with number 'row' of this matrix as a 1D-Array.
      /// </summary>
      public static T[] GetRow<T>(this T[,] matrix, int row)
      {
        var rowLength = matrix.GetLength(1);
        var rowVector = new T[matrix.GetLength(1)];
        Array.Copy(matrix, row * rowLength, rowVector, 0, rowLength);
        //for (var i = 0; i < matrix.GetLength(1); i++)
        //  rowVector[i] = matrix[row, i];
        return rowVector;
      }
    
      /// <summary>
      /// Sets the row with number 'row' of this 2D-matrix to the parameter 'rowVector'.
      /// </summary>
      public static void SetRow<T>(this T[,] matrix,  int row, T[] rowVector)
      {
        var rowLength = matrix.GetLength(1);
        Array.Copy(rowVector, 0, matrix, row * rowLength, rowLength);
        //for (var i = 0; i < matrix.GetLength(1); i++)
        //  matrix[row, i] = rowVector[i];
      }
    
      /// <summary>
      /// Returns the column with number 'col' of this matrix as a 1D-Array.
      /// </summary>
      public static T[] GetCol<T>(this T[,] matrix, int col)
      {
        var colVector = new T[matrix.GetLength(0)];
        for (var i = 0; i < matrix.GetLength(1); i++)
          colVector[i] = matrix[i, col];
        return colVector;
      }
      /// <summary>
      /// Sets the column with number 'col' of this 2D-matrix to the parameter 'colVector'.
      /// </summary>
      public static void SetCol<T>(this T[,] matrix, int col, T[] colVector)
      {
        for (var i = 0; i < matrix.GetLength(0); i++)
          matrix[i, col] = colVector[i];
      }
    }
