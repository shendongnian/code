    public override DataTable GetRecords(WhateverClassThisIs dataAccess, QueryContext queryContext, out int totalRecords)    
    {
        // Build Query
        StringBuilder query = new StringBuilder("SELECT * FROM TABLE");
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        
        // Order By Clause
        query.Append(queryContext.OrderByColumns.GetSqlClause());
        // Apply Limit
        if (queryContext.ApplyLimit)
        {
            query.AppendFormat(" LIMIT {0},{1}", queryContext.Offset, queryContext.Limit);
        }
        //Execute the query.
        DataSet results = dataAccess.ExecuteQuery(query.ToString(), parameters);
        totalRecords = Convert.ToInt32(results.Tables[1].Rows[0][0]);
        return results.Tables[0];
    }
