    public static bool In<T>(this T obj, params T[] values)
    {
        for (int i=0; i < values.Length; i++)
        {
             if (object.Equals(obj, values[i]))
                 return true;
        }
        return false;
    }
