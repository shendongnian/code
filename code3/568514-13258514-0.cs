    var storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
    var table = storageAccount.CreateCloudTableClient()
                                .GetTableReference("tempTable");
    table.CreateIfNotExists();
    // Add item.
    table.Execute(TableOperation.Insert(new TableEntity("MyItems", "123")));
    // Load items.
    var items = table.ExecuteQuery(new TableQuery<TableEntity>());
    foreach (var item in items)
    {
        Console.WriteLine(item.PartitionKey + " - " + item.RowKey);
    }
    // Delete item (the ETAG is required here!).
    table.Execute(TableOperation.Delete(new TableEntity("MyItems", "123") { ETag = "*" }));
