    public static IEnumerable<TOut> ConvertTo<TIn, TOut>(this IEnumerable<TIn> list)
    {
        return list.Select(o => (TOut)Convert.ChangeType(o, typeof (TOut)));
    }
    List<string> strList = new List<string>();
    IEnumerable<int> intList = strList.ConvertTo<string, int>();
