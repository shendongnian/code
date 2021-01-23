    Parallel.Invoke(new ParallelOptions(), () =>
        {
            lock (securitiesLock)
            {
                while (!args.securitiesUpdates.IsNullOrEmpty())
                    securities.Enqueue(args.securitiesUpdates.Dequeue());
            }
        },
        () =>
        {
            lock (orderUpdatesLock)
            {
                while (!args.orderUpdates.IsNullOrEmpty())
                    orderUpdates.Enqueue(args.orderUpdates.Dequeue());
            }
        },
        () =>
        {
            lock (quotesLock)
            {
                while (!args.quotesQueue.IsNullOrEmpty())
                    quotes.Enqueue(args.quotesQueue.Dequeue());
            }
        });
