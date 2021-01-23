    private static bool IsSubMatrix(int[][] a, int[][] b)
    {
         for (int i = 0; i < a.Length - b.Length + 1; i++)
         {
             for (int j = 0; j < a[0].Length - b[0].Length + 1; j++)
             {
                  bool found = true;
                  for (int k = 0; k < b.Length; ++k)
                  {
                      for (int l = 0; l < b[0].Length; ++l)
                      {
                          if (a[i + k][j + l] != b[k][l])
                          {
                              found = false;
                              break;
                          }
                      }
                      if (!found) break;
                  }
                  if (found) return true;
              }
          }          
          return false;
     }
