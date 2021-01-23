    var query = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("Level", QueryComparisons.Equal, "ERROR"), 
                TableOperators.And, 
                TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, DateTimeOffset.Now.AddDays(-20).Date));
            
    var query2 = TableQuery.CombineFilters(query,
                TableOperators.And, 
                TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.LessThanOrEqual, DateTimeOffset.Now));
    var exQuery = new TableQuery<LogEntry>().Where(query2);
    CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();
    CloudTable table = tableClient.GetTableReference(_tableName);
    var results = table.ExecuteQuery(exQuery).Select(ent => (T) ent).ToList();
