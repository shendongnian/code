    public static bool In(this object item, IEnumerable list)
    {
        return list.Contains(item);
    }
    public static bool In(this object item, params object[] list)
    {
        return item.In(list);
    }
