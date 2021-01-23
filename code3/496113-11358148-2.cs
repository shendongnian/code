    public static bool In<T>(this T source, params T[] list)
    {
       if (source = null)
           throw new NullReferenceException("Source is Null");
       return list.Contains(source);
    }
