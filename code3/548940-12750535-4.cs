        private static void SequentialInserts(CloudTableClient client)
        {
            var context = client.GetDataServiceContext();
            Trace.WriteLine("Starting sequential inserts.");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
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
            stopwatch.Stop();
            Trace.WriteLine("Done in: " + stopwatch.Elapsed.ToString());
        }
