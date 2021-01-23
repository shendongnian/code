    static async Task MultiplyMatricesAsync(double[,] matA, double[,] matB, double[,] result)
    {
      int matACols = matA.GetLength(1);
      int matBCols = matB.GetLength(1);
      int matARows = matA.GetLength(0);
      var tasks = Enumerable.Range(0, matARows).Select(i =>
          Task.Run(() =>
          {
            for (int j = 0; j < matBCols; j++)
            {
              // Use a temporary to improve parallel performance.
              double temp = 0;
              for (int k = 0; k < matACols; k++)
              {
                temp += matA[i, k] * matB[k, j];
              }
              result[i, j] = temp;
            }
          }));
      await Task.WhenAll(tasks);
    }
