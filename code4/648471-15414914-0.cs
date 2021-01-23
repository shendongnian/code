    public static bool ContentEquals<T>(this T[,] arr, T[,] other) where T : IComparable
    {
        if (arr.GetLength(0) != other.GetLength(0) ||
            arr.GetLength(1) != other.GetLength(1))
            return false;
        for (int i = 0; i < arr.GetLength(0); i++)
            for (int j = 0; j < arr.GetLength(1); j++)
                if (arr[i, j].CompareTo(other[i, j]) != 0)
                    return false;
        return true;
    }
