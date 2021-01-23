    private int _pendingMessages;
        public void Write(INetworkSerializable messageToSend)
        {
            var messageIndex = Interlocked.Increment(ref _pendingMessages);
            Queue.Enqueue(messageToSend);
            // Check if we have added very first message to queue, then we will have to become a consumer and process our own message, and any other further messages until we have cleaned the queue
            if (messageIndex == 1)
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
                    // Well in this case that thread will consider itself as a thread which had added First message in queue and will try to become a consumer,
                    // so let's not interfere with it, and just finish "consuming" items in our current thread. 
                    // this means that all other messages including that newly added message will be processed by other "consumer" thread.
                    if (dataToSendList.Count == 0)
                    {
                        // and if we have no data this mean that we are safe to exit from current thread.
                        return;
                    }
                    // We have data in the list to send but nothing more to consume so lets send the data that we do have.             
                    break;
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
            // Data was written to sockets, we do not have to return to main loop, as this is not our responcibility anymore.
        }
