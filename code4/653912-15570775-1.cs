    public static Tuple<List<T1>> GetSprocResults<T1>(DataTableReader reader)
    {
        var t1 = ObjectContext.Translate<T1>(reader).ToList();
        return new Tuple<List<T1>>(t1);
    }
    public static Tuple<List<T1>, List<T2>> GetSprocResults<T1, T2>(DataTableReader reader)
    {
        var t1 = ObjectContext.Translate<T1>(reader).ToList();
        reader.NextResult();
        var t2 = ObjectContext.Translate<T1>(reader).ToList();
        reader.NextResult();
        return new Tuple<List<T1>, List<T2>>(t1, t2);
    }
