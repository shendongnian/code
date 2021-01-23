    private int _pendingMessages;
        private int _consuming;
        public void Write(INetworkSerializable messageToSend)
        {
            Interlocked.Increment(ref _pendingMessages);
            Queue.Enqueue(messageToSend);
            // Check if there is anyone consuming messages
            // if not, we will have to become a consumer and process our own message, 
            // and any other further messages until we have cleaned the queue
            if (Interlocked.CompareExchange(ref _consuming, 1, 0) == 0)
            {
                // We are now the thread that consumes and sends data
                SendNewData();
            }
        }
        // Only one thread should be looping here to keep consuming and sending data synchronously.
        private void SendNewData()
        {
            INetworkSerializable dataToSend;
            var dataToSendList = new List<INetworkSerializable>();
            int messagesLeft;
            do
            {
                if (!Queue.TryDequeue(out dataToSend))
                {
                    // there is one possibility that we get here while _pendingMessages != 0:
                    // some other thread had just increased _pendingMessages from 0 to 1, but haven't put a message to queue.
                    if (dataToSendList.Count == 0)
                    {
                        if (_pendingMessages == 0)
                        {
                            _consuming = 0;
                            // and if we have no data this mean that we are safe to exit from current thread.
                            return;
                        }
                    }
                    else
                    {
                        // We have data in the list to send but nothing more to consume so lets send the data that we do have.             
                        break;
                    }
                }
                dataToSendList.Add(dataToSend);
                messagesLeft = Interlocked.Decrement(ref _pendingMessages);
            }
            while (messagesLeft > 0);
            // Async callback is WriteAsyncCallback()
            WriteAsync(dataToSendList);
        }
        private void WriteAsync(List<INetworkSerializable> dataToSendList)
        {
            // some code
        }
        // Callback after WriteAsync() has sent the data.
        private void WriteAsyncCallback()
        {
            // ...
            SendNewData();
        }
