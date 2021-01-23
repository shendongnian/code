    public static bool IsSorted<T>(IEnumerable<T> list) where T:IComparable<T>
    {
        var y = list.First();
        return list.Skip(1).All(x =>
        {
            bool b = y.CompareTo(x) < 0;
            y = x;
            return b;
        });
    }
