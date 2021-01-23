    var source = TableServiceContext.CreateQuery<entity>(tableName).Where(e=>e.PartitionKey == entity.PartitionKey  && e.RowKey == entity.RowKey);
    
    if(source != null && source.Any())
    {
        var existingObject = source.FirstOrDeFault();
        // do somthing with existingObject 
    }else
    {
        // existingObject is null 
    }
