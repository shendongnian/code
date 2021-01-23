    CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
    CloudTable table = storageAccount.CreateCloudTableClient().GetTableReference("Employee");
    DynamicTableEntity entity = new DynamicTableEntity()
    {
        PartitionKey = "Employee",
        RowKey = "01",
    };
    Dictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>();
    properties.Add("Name", new EntityProperty("John Smith"));
    properties.Add("DOB", new EntityProperty(new DateTime(1971, 1, 1)));
    properties.Add("MaritalStatus", new EntityProperty("Single"));
    entity.Properties = properties;
    TableOperation insertOperation = TableOperation.Insert(entity);
    table.Execute(insertOperation);
    DynamicTableEntity updatedEntity = new DynamicTableEntity()
    {
        PartitionKey = "Employee",
        RowKey = "01",
        ETag = "*",
    };
    Dictionary<string, EntityProperty> newProperties = new Dictionary<string, EntityProperty>();
    newProperties.Add("MaritalStatus", new EntityProperty("Married"));
    updatedEntity.Properties = newProperties;
    TableOperation mergeOperation = TableOperation.Merge(updatedEntity);
    table.Execute(mergeOperation);
