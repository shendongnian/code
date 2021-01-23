    class MessageController
    {
        private BlockingCollection<IMessage> messageQueue = new BlockingCollection<IMessage>();
    
        public void Enqueue(IMessage message)
        {
            messageQueue.Add(message);
        }
    
        public void Consume()
        {
            //This loop will not exit until messageQueue.CompleteAdding() is called
            foreach (var item in messageQueue.GetConsumingEnumerable())
            {
                IMessage message = item;
                Task.Run(() => ProcessMessage(message);
            }
        }
    }
