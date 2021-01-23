    static void GenericEntry<T, TK>(string userid, string environment, 
                                    DBContext context, Func<T, TK> conversion) 
    {
        //....
        var resultList = new List<TK>();
        foreach (var row in results)
        {
            var poco = conversion(row);
            resultList.Add(poco);
        }
        //....
    }
 
