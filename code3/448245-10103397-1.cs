    class ProducerConsumer
    {
        private static BlockingCollection<string> queue = new BlockingCollection<string>();
    
        static void Main(string[] args)
        {
            Start();
        }
    
        public static void Start()
        {
            var producerWorker = Task.Factory.StartNew(() => ProducerImpl());
            var consumerWorker = Task.Factory.StartNew(() => ConsumerImpl());
    
            Task.WaitAll(producerWorker, consumerWorker);
        }
    
        private static  void ProducerImpl()
        {
            int itemsCount = 100;
    
            while (itemsCount-- > 0)
            {
                queue.Add(itemsCount + " - " + Guid.NewGuid().ToString());
                Thread.Sleep(250);
            }
        }
    
        private static void ConsumerImpl()
        {
            foreach (var item in queue.GetConsumingEnumerable())
            {
               Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffff") + " | " + item);
            }
        }
    }
