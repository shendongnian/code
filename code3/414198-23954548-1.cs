    public class ManageBatchProcessing 
    {
        private  BlockingCollection<Action> blockingCollection;
        public void Process()
        {
            blockingCollection = new BlockingCollection<Action>();
            int numberOfBatches = 10;
            Process(HandleProducers, HandleConsumers, numberOfBatches);
        }
        private void Process(Action<int> produce, Action<int> consume, int numberOfBatches)
        {
            produce(numberOfBatches);
            consume(numberOfBatches);
        }
        private void HandleConsumers(int numberOfBatches)
        {
            var consumers = new List<Task>();
            for (var i = 1; i <= numberOfBatches; i++)
            {
                consumers.Add(Task.Factory.StartNew(() =>
                {
                    foreach (var action in blockingCollection.GetConsumingEnumerable())
                    {
                        action();
                    }
                }));
            }
            Task.WaitAll(consumers.ToArray());
        }
        private void HandleProducers(int numberOfBatches)
        {
            var producers = new List<Task>();
            for (var i = 0; i <= numberOfBatches; i++)
            {
                producers.Add(Task.Factory.StartNew(() =>
                {
                    blockingCollection.Add(() => YourProdcerMethod());
                }));
            }
            Task.WaitAll(producers.ToArray());
            blockingCollection.CompleteAdding();
        }
    }
