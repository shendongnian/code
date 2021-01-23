    public static Tuple<List<T1>> GetSprocResults<T1>
        (DataTableReader reader, ObjectContext objectContext)
    {
        var t1 = objectContext.Translate<T1>(reader).ToList();
        return new Tuple<List<T1>>(t1);
    }
    public static Tuple<List<T1>, List<T2>> GetSprocResults<T1, T2>
        (DataTableReader reader, ObjectContext objectContext)
    {
        var t1 = objectContext.Translate<T1>(reader).ToList();
        reader.NextResult();
        var t2 = objectContext.Translate<T2>(reader).ToList();
        return new Tuple<List<T1>, List<T2>>(t1, t2);
    }
