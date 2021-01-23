    var existingObject = TableServiceContext.CreateQuery<entity>(tableName).Where(e=>e.PartitionKey == entity.PartitionKey  && e.RowKey == entity.RowKey).FirstOrDefault();
    
    if(existingObject !=null)
    {
      // add
    }else
    {
     //.......
    }
