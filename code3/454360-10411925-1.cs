    class BlockCollectionExtensionsTest
    {
        [Fact]
        public void AsRateLimitedObservable()
        {
            const int maxItems = 1; // fix this to 1 to ease testing
            TimeSpan during = TimeSpan.FromSeconds(1);
            // populate collection
            int[] items = new[] { 1, 2, 3, 4 };
            BlockingCollection<int> collection = new BlockingCollection<int>();
            foreach (var i in items) collection.Add(i);
            collection.CompleteAdding();
            IObservable<int> observable = collection.AsRateLimitedObservable(maxItems, during, CancellationToken.None);
            BlockingCollection<int> processedItems = new BlockingCollection<int>();
            ManualResetEvent completed = new ManualResetEvent(false);
            DateTime last = DateTime.UtcNow;
            observable
                // this is so we'll receive exceptions
                .ObserveOn(new SynchronizationContext()) 
                .Subscribe(item =>
                    {
                        if (item == 1)
                            last = DateTime.UtcNow;
                        else
                        {
                            TimeSpan diff = (DateTime.UtcNow - last);
                            last = DateTime.UtcNow;
                            Assert.InRange(diff.TotalMilliseconds,
                                during.TotalMilliseconds - 30,
                                during.TotalMilliseconds + 30);
                        }
                        processedItems.Add(item);
                    },
                    () => completed.Set()
                );
            completed.WaitOne();
            Assert.Equal(items, processedItems, new CollectionEqualityComparer<int>());
        }
    }
