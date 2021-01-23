    public static int IndexOf(this IEnumerable<T> list, T item)
    {
        int index = 0;
        foreach(var l in list)
        {
            if(l.Equals(item))
                return index;
            index++;
        }
        return -1;
     }
