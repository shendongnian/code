    public void UpdateEntityProperty<T>(string partitionKey, string rowKey,
                                        string propertyName, T newPropertyValue)
    {
      TableOperation retrieveOperation = TableOperation.Retrieve(partitionKey, rowKey);
      TableResult retrievedResult = table.Execute(retrieveOperation);
      TableEntity entity = (TableEntity)retrievedResult.Result;
    
      // This  line, of course, doesn't compile. But you get the idea.
      entity.SetPropertyValue(propertyName, newPropertyValue);
    
      TableOperation mergeOperation = TableOperation.Merge(entity);
      table.Execute(mergeOperation);
    }
