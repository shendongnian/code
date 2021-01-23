    public static IEnumerable<T> GetRow<T>(this T[,] array, int rowIndex)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            yield return array[rowIndex, i];
        }
    }
