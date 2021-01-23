    public static bool IsNullOrEmpty(this ICollection collection)
    {
        if (collection == null)
            return true;
        return  collection.Count < 1;
    }
