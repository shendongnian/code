    public override DataTable GetRecords(QueryContext queryContext, String queryString, List<String> parameters, out int totalRecords)
    {
        StringBuilder query = new StringBuilder(queryString);
   
        if (queryContext.OrderByColumns.Count == 0)
        {
            foreach(String str in params)
            {
                queryContext.OrderByColumns.Add(str);
            }
        }
        .....
    }
