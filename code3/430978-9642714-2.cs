    public static bool ContainsType<T>(this T[] arr, Type type)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i].GetType().Equals(type))
                return true;
        return false;
    }
