    public static IEnumerable<Tuple<Bar, Foo>> Merge(IEnumerable<Bar> pACList
        , IEnumerable<Foo> pList)
    {
        return pACList.Join(pList, item => item.Key.ToString()
            , item => item.CompanyID.ToString()
                , (a, b) => Tuple.Create(a, b));
    }
