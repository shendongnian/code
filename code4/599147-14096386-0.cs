    public static void Insert<T>(this T[] array, int position, T item)
    {
        for ( int i = array.Length-1; i > position; i-- )
            array[i] = array[i-1];
        array[position] = item;
    }
