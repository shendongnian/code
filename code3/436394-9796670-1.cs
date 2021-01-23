        // 1. Use static class. By the agreement, all helper classes should be static to avoid 
        // IDisposable inheritance, in example
        public static class MsmqHelper//: IDisposable
        {
            //private MessageQueue _messageQueue;
         
            //public MessageQueueHelper(bool workflowCreated)
            //{
            //    this._messageQueue = MsmqHelper.InitializeQueue();
            //    this._messageQueue.Send(workflowCreated);
            //}
        
            public static SendMessage(object workflowCreated)
            {
                // 2. If static method in static class does not takes parameters, 
                // I might be better to to implicitly call the constructor?
                // using(MessageQueue msmsq = MsmqHelper.InitializeQueue())
                using(MessageQueue msmsq = new MessageQueue()
                {
                    msmq.Send(workflowCreated);
                    msmq.Close(); 
         
                    // MsmqHelper.DisposeQueue(msmq);
    
                    // 3. You should explicitly call Close object to immediately release     
                    // unmanaged resources, while managed ones will be released 
                    // at next GC rounds, as soon as possible
                }
            }
            //private MessageQueue _messageQueue;
        
            //public void Dispose()
            //{
            //    Dispose(true);
            //    GC.SuppressFinalize(this);
            //}
        
            //private void Dispose(bool disposing)
            //{
        //    if (disposing == false) { return; }
        //
        //    MsmqHelper.DisposeQueue(this._messageQueue);
        //}
        
        //public static void DisposeQueue(MessageQueue messageQueue)
        //{
        //    if (messageQueue != null)
        //    {
        //        messageQueue.Close();
        //        messageQueue.Dispose();
        //        messageQueue = null;
        //    }
        //}
    }
