    public static T[] ToArray<T>(this Array array)
    {
        if (array == null)
            return null;
        if (array.Rank != 1)
            throw new NotSupportedException();
        var newArray = new T[array.GetLength(0)];
        var lb = array.GetLowerBound(0);
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = (T)array.GetValue(i + lb);
        }
        return newArray;
    }
