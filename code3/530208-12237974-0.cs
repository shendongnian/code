    public static IEnumerable<T> SliceX<T>(T[,,] data, int x) {
      for (int y = 0; y < data.GetLength(1); y++) {
        for (int z = 0; z < data.GetLength(2); z++) {
          yield return data[x, y, z];
        }
      }
    }
