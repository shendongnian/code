    public T GetMinimum<T>(T[] array, params T[] ignorables) where T : IComparable<T>
    {
        T result = array[0]; //some issue with the logic here.. what if array is empty
        foreach (T item in array)
        {
            if (ignorables.Contains(item)
                continue;
            if (result.CompareTo(item) > 0)
            {
                result = item;
            }
        }
        return result;
    }
