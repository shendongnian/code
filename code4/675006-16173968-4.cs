    var cloudTable = cloudTableClient.GetTableReference("TheTable");
    
    var entity = new DynamicTableEntity("ThePartitionKey", "TheRowKey");
    entity.ETag = "*";
    
    cloudTable.Execute(TableOperation.Delete(entity));
