    public static List<string> ItemsOfEnum<typeT>()
            where typeT: struct, IComparable, IFormattable, IConvertible {
        List<string> items = new List<string>();
        foreach (typeT tItem in Enum.GetValues(typeof(typeT)))
           items.Add(tItem.ToString());
        return items;
    }
