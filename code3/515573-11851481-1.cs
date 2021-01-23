    var queue = new BlockingCollection<Uri>();
    var maxClients = 4;
    // Optionally provide another producer/consumer collection for the data
    // var data = new BlockingCollection<Tuple<Uri,byte[]>>();
    // Optionally implement CancellationTokenSource
    var clients = from id in Enumerable.Range(0, maxClients)
                  select Task.Factory.StartNew(
        () =>
        {
            var client = new WebClient();
            while (!queue.IsCompleted)
            {
                Uri uri;
                if (queue.TryTake(out uri))
                {
                    byte[] datum = client.DownloadData(uri); // already "async"
                    // Optionally pass datum along to the other collection
                    // or work on it here
                }
                else Thread.SpinWait(100);
            }
        });
    // Add URI's to search
    // queue.Add(...);
    // Notify our clients that we've added all the URI's
    queue.CompleteAdding();
    // Wait for all of our clients to finish
    clients.WaitAll();
