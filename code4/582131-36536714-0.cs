    // Get the cloudtable ...
    var table = GetCloudTable();
    // Create a query: in this example I use the DynamicTableEntity class
    var query = cloudTable.CreateQuery<TestEntity>()
        .Where(d => d.PartitionKey == "what's up" && d.RowKey == "blah");
    var entities = query.ToList();
