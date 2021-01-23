    List<Document> results = null;
    var client = new AmazonDynamoDBClient("myamazonkey", "myamazonsecret");
    var table = Table.LoadTable(client, "mytable");
    var batchWrite = table.CreateBatchWrite();
    var batchCount = 0;
    
    var search = table.Query(new Primitive("hashkey"), new RangeFilter());
    do {
      results = search.GetNextSet();
      search.Matches.Clear();
      foreach (var document in results)
      {
        batchWrite.AddItemToDelete(document);
        batchCount++;
        if (batchCount%25 == 0)
        {
          batchCount = 0;
          try
          {
            batchWrite.Execute();
          }
          catch (Exception exception)
          {
           Console.WriteLine("Encountered an Amazon Exception {0}", exception);
          }
          batchWrite = table.CreateBatchWrite();
         }
       }
       if (batchCount > 0) batchWrite.Execute();
      }
    } while(results.Count > 0);
