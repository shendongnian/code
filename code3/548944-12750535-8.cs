        private static void ParallelInserts(CloudTableClient client)
        {            
            Trace.WriteLine("Starting parallel inserts.");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var partitioner = Partitioner.Create(0, 1000, 10);
            var options = new ParallelOptions { MaxDegreeOfParallelism = 8 };
            Parallel.ForEach(partitioner, options, range =>
            {
                var context = client.GetDataServiceContext();
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    Trace.WriteLine(String.Format("Adding item {0}. Thread ID: {1}", i, Thread.CurrentThread.ManagedThreadId));
                    context.AddObject(TABLENAME, new MyEntity()
                    {
                        Date = DateTime.UtcNow,
                        PartitionKey = "Test",
                        RowKey = Guid.NewGuid().ToString(),
                        Text = String.Format("Item {0} - {1}", i, Guid.NewGuid().ToString())
                    });
                    context.SaveChanges();
                }
            });
            
            stopwatch.Stop();
            Trace.WriteLine("Done in: " + stopwatch.Elapsed.ToString());
        }
