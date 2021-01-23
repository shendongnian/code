        private  async Task<Message> MyAsyncReceive()
        {
            var queue=new MessageQueue();
            
            var message=await Task.Factory.FromAsync<Message>(queue.BeginPeek(),queue.EndPeek);
            using (var tx = new MessageQueueTransaction())
            {
                tx.Begin();
                queue.Receive(tx);
                //Process the results inside a transaction
                tx.Commit();
            }
            return message;
        }
