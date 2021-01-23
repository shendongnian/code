    public static T[] Row<T>(this T[,] arr, int row)
    {
        if (row > arr.GetLength(0))
            throw new ArgumentOutOfRangeException("No such row in array.", "row");
        var result = new T[arr.GetLength(1)];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = arr[row, i];
        }
        return result;
    }
