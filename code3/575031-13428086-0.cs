        static void ExecuteQuery()
        {
            TableContinuationToken token = null;
            TableRequestOptions reqOptions = new TableRequestOptions() { };
            OperationContext ctx = new OperationContext() { ClientRequestID = "" };
            long totalEntitiesRetrieved = 0;
            while (true)
            {
                CloudTable table = cloudTableClient.GetTableReference("MyTable");
                TableQuery<TempEntity> query = (new TableQuery<TempEntity>()).Take(100);
                System.Threading.ManualResetEvent evt = new System.Threading.ManualResetEvent(false);
                var result = table.BeginExecuteQuerySegmented<TempEntity>(query, token, reqOptions, ctx, (o) =>
                {
                    var response = (o.AsyncState as CloudTable).EndExecuteQuerySegmented<TempEntity>(o);
                    token = response.ContinuationToken;
                    int recordsRetrieved = response.Count();
                    totalEntitiesRetrieved += recordsRetrieved;
                    Console.WriteLine("Records retrieved in this attempt = " + recordsRetrieved + " | Total records retrieved = " + totalEntitiesRetrieved);
                    evt.Set();
                }, table);
                evt.WaitOne();
                if (token == null)
                {
                    break;
                }
            }
        }
