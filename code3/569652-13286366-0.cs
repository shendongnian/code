    public static IEnumerable<T> SortEmployeesFor<T>(IEnumerable<T> list, OrderOptions options)
    {
        switch (options)
        {
            case OrderOptions.1:
                list = from t in list
                         orderby t.property1, t.property2
                         select t;
            case OrderOptions.2:
                list = from t in list
                         orderby t.property2, t.property1
                         select t;        
            .
            .
            .
        }
        return list;
    }
