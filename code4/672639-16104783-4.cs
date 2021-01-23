        private  async Task<Message> MyAsyncReceive()
        {
            MessageQueue queue=new MessageQueue();
            ...
            var message=await Task.Factory.FromAsync<Message>(
                               queue.BeginReceive(),
                               queue.EndReceive);
            return message;
            
        }
