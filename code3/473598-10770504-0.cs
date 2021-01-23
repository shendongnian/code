    static void Fill<T>(T[] array, T value)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            array[i] = value;
        }
    }
