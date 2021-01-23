    public override DataTable GetRecords(QueryContext queryContext, string[] queryParams, out int totalRecords)
    {
        // Build Query
        //Different
        StringBuilder query = new StringBuilder("SELECT * FROM TABLE");
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        
        if (queryContext.OrderByColumns.Count == 0)
        {
            foreach(string param in queryParams) {
               queryContext.OrderByColumns.Add(param);
             }
        }
       ...
}
