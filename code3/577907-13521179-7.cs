    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
    {
        int itemCount = list.Count();
        int itemOnIndex = 0;
        var splits = from item in list
                     group item by MethodToDefineRow(itemCount, itemOnIndex++) into row
                     select row.AsEnumerable();
        return splits;
    }
