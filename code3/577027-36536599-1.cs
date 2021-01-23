    public List<T> GetEntities<T>(string partitionKey, T entity) where T : ITableEntity, new()
    {
        try
        {
            var tableClient = _account.CreateCloudTableClient();
            var table = tableClient.GetTableReference(entity.GetType().Name.ToLower());
            return table.CreateQuery<T>().Where(e => e.PartitionKey == partitionKey).ToList();
        }
        catch (StorageException ex)
        {
            //TODO: Add more trace info
            Trace.TraceInformation("Unable to retrieve entity based on query specs");
            return null;
        }
    }
