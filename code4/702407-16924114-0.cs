    public static IEnumerable<T> GetColumn<T>(T[,] array, int column)
    {
        for (int i = 0; i < array.GetLength(0); i++)
            yield return array[i, column];
    }
