    testtable.Execute(
      TableOperation.InsertOrReplace(firstRetrieve),
      null,
      new OperationContext {
        UserHeaders = new Dictionary<String, String>
                          {
                            { "If-Match", firstRetrieve.ETag }
                          }
      }
    );
