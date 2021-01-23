        /*
         
         The following overloads of ExecuteQuerySegmentedAsync is executed like this)
         */
            CloudTableClient client = acct.CreateCloudTableClient();
            CloudTable tableSymmetricKeys = client.GetTableReference("SymmetricKeys5");
            TableContinuationToken token = new TableContinuationToken() { };
            TableRequestOptions opt = new TableRequestOptions() { };
            OperationContext ctx = new OperationContext() { ClientRequestID = "ID" };
            CancellationToken cancelToken = new CancellationToken();
            List<Task> taskList = new List<Task>();
         
               while (true)
                {
                    Task<TableQuerySegment<DynamicTableEntity>> task3 = tableSymmetricKeys.ExecuteQuerySegmentedAsync(query, token, opt, ctx, cancelToken);
                    // Run the method
                    task3.Wait();
                    token = task3.Result.ContinuationToken;
                    Console.WriteLine("Records retrieved in this attempt = " + task3.Result.Count ()); 
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
         */
       // Overload #4
            public static Task<TableQuerySegment<DynamicTableEntity>> ExecuteQuerySegmentedAsync(this CloudTable tbl, TableQuery query, TableContinuationToken continuationToken, TableRequestOptions opt, OperationContext ctx     ,CancellationToken token )
            {
                ICancellableAsyncResult result = null;
    
                if (opt == null && ctx == null)
                    result = tbl.BeginExecuteQuerySegmented(query, continuationToken, null, tbl);
                else
                    result = tbl.BeginExecuteQuerySegmented(query, continuationToken, opt, ctx, null, tbl);
    
                // Add cancellation token according to guidance from Table Client 2.0 Breaking Changes blog entry
                var cancellationRegistration = token.Register(result.Cancel);
    
                return Task.Factory.FromAsync(result, iAsyncResult =>
                {
                    CloudTable currentTable = iAsyncResult.AsyncState as CloudTable;
    
                    //cancellationRegistration.Dispose();
                    return currentTable.EndExecuteQuerySegmented(result);
                });
            }
