    public void UpdateEntityProperty(string partitionKey, string rowKey,
                                     string propertyName, string newPropertyValue)
    {
        var entity = new DynamicTableEntity(partitionKey, rowKey);
        var properties = new Dictionary<string, EntityProperty>();
        properties.Add(propertyName, new EntityProperty(newPropertyValue));
        var mergeOperation = TableOperation.Merge(entity);
        table.Execute(mergeOperation);
    }
