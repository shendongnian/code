    var batchOperation = new TableBatchOperation();
    
    // We need to pass at least one property to project or else 
    // all properties will be fetch in the operation
    var projectionQuery = new TableQuery<DynamicTableEntity>()
        .Where(TableQuery.GenerateFilterCondition("PartitionKey", 
            QueryComparisons.Equal, "ThePartitionKey"))
        .Select(new string[] { "RowKey" });
    
    foreach (var e in table.ExecuteQuery(projectionQuery))
    	batchOperation.Delete(e);
    
    table.ExecuteBatch(batchOperation);
