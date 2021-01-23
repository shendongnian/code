    public class AzureTableQueryState
    {
        public CloudTable CloudTable { get; set; }
        public TableContinuationToken Token { get; set; }
        public ManualResetEvent Evt { get; set; } //i'm guessing that's what this is
        //any other variables you were using
        public int TotalEntitiesRetrieved { get; set; }
    }
      // snip....
                while (true)
                { 
                    // Initialize variables
                    TableQuery  query = (new TableQuery()).Take(100);
                    AzureTableQueryState queryState = new AzureTableQueryState();
                    queryState.Evt = new System.Threading.ManualResetEvent(false);
                    queryState.TotalEntitiesRetrieved = 0;
                    AsyncCallback asyncCallback = (iAsyncResult) =>
                    {
                        AzureTableQueryState state = iAsyncResult.AsyncState as AzureTableQueryState;
                        var response = state.CloudTable.EndExecuteQuerySegmented(iAsyncResult);
                        token = response.ContinuationToken;
                        int recordsRetrieved = response.Results.Count;
                        state.TotalEntitiesRetrieved += recordsRetrieved;
                        Console.WriteLine("Records retrieved in this attempt = " + recordsRetrieved + " | Total records retrieved = " + state.TotalEntitiesRetrieved);
                        state.Evt.Set();
                    };
                    // Run the method
                    var result = tableSymmetricKeys.BeginExecuteQuerySegmented(query, token, opt, ctx, asyncCallback, tableSymmetricKeys);
                    
                    // Add cancellation token according to guidance from Table Client 2.0 Breaking Changes blog entry
                    cancelToken.Register((o) => result.Cancel(), null);
                    queryState.Evt.WaitOne();
                    if (token == null)
                    {
                        break;
                    }
                    else
                    {
                        // persist token
                        // token.WriteXml()
                    }
                }
