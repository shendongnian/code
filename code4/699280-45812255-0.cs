    return (Entity)retrievedResult.Result;
    
    class Entity : TableEntity
    {
        public string PartKey => PartitionKey;
        public string RowKey => RowKey;
    }
