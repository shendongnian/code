    public static IEnumerable<T[]> GetRows<T>(T[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            T[] row = new T[array.GetLength(1)];
            for (int j = 0; j < row.Length; j++)
            {
                row[j] = array[i, j];
            }
            yield return row;
        }
    }
