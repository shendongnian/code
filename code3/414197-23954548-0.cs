    public class ManageBatchProcessing 
    {
        private readonly static BlockingCollection<Action> BlockingCollection = new BlockingCollection<Action>();
        public void Process()
        {
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
                    foreach (var value in BlockingCollection.GetConsumingEnumerable())
                    {
                        value();
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
                    BlockingCollection.Add(() => YourProdcerMethod());
                }));
            }
            Task.WaitAll(producers.ToArray());
            BlockingCollection.CompleteAdding();
        }
    }
