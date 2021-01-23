        private  async Task<Message> MyAsyncReceive()
        {
            var queue=new MessageQueue();
            
            var message=await Task.Factory.FromAsync<Message>(queue.BeginPeek(),queue.EndPeek);
            using (var tx = new MessageQueueTransaction())
            {
                tx.Begin();
                //Someone may have taken the last message, don't wait forever
                //Use a smaller timeout if the queue is local
                message=queue.Receive(TimeSpan.FromSeconds(1), tx);
                //Process the results inside a transaction
                tx.Commit();
            }
            return message;
        }
