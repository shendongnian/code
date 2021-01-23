    public static T[] RemoveDuplicates<T>(this T[] array)
    {
        return array.Distinct().ToArray();
    }
    public static List<T> RemoveDuplicates<T>(this List<T> list)
    {
        return list.Distinct().ToList();
    }
