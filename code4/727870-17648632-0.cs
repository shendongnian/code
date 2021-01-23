    public static T2 ToT2(this T1 t1)
    {
        return new T2 { ID = t1.ID, Name = t1.Name };
    }
    public static List<T2> ToT2List(this IEnumerable<T1> t1List)
    {
        return t1List.Select(t1 => t1.ToT2()).ToList();
    }
