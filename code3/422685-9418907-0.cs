     static public void Init<T>(this T[,] array) where T : new()
     {
        for (int y = 0; y < array.GetLength(0); y++)
        {
           for (int x = 0; x < array.GetLength(1); x++)
           {
              array[y, x] = new T();
           }
        }
      }
