    class ProducerConsumer
    {
        private static BlockingCollection<string> queue = new BlockingCollection<string>();
    
        static void Main(string[] args)
        {
            Start();
        }
    
        public static void Start()
        {
            var producerWorker = Task.Factory.StartNew(() => RunProducer());
            var consumerWorker = Task.Factory.StartNew(() => RunConsumer());
    
            Task.WaitAll(producerWorker, consumerWorker);
        }
    
        private static void RunProducer()
        {
            int itemsCount = 100;
    
            while (itemsCount-- > 0)
            {
                queue.Add(itemsCount + " - " + Guid.NewGuid().ToString());
                Thread.Sleep(250);
            }
        }
    
        private static void RunConsumer()
        {
            foreach (var item in queue.GetConsumingEnumerable())
            {
               Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffff") + " | " + item);
            }
        }
    }
