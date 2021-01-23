    class MessageController
    {
        private BlockingCollection<IMessage> messageQueue = new BlockingCollection<IMessage>();
        private ManualResetEvent mre = new ManualResetEvent(true);
        private int amountOfConsumers;
        object o = new object();
        public void Enqueue(IMessage message)
        {
            messageQueue.Add(message);
            mre.WaitOne();
            if (Math.Floor((double)messageQueue.Count / 100)+1 > amountOfConsumers)
            {
                Interlocked.Increment(ref amountOfConsumers);
                var task = Task.Factory.StartNew(() =>
                {
                    IMessage msg;
                    bool repeat = true;
                    while (repeat)
                    {
                        while ((messageQueue.Count > 0) && (Math.Floor((double)((messageQueue.Count + 50) / 100)) + 1 >= amountOfConsumers))
                        {
                            msg = messageQueue.Take();
                            //process msg...
                        }
                        lock (o)
                        {
                            if ((messageQueue.Count == 0) || (Math.Ceiling((double)((messageQueue.Count + 51) / 100)) < amountOfConsumers))
                            {
                                mre.Reset();
                                ConsumerQuit();
                                mre.Set();
                                repeat = false;
                            }
                        }
                    }
                });
            }
        }
        public void ConsumerQuit()
        {
            Interlocked.Decrement(ref amountOfConsumers);
        }
    }
