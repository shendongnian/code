    public int SendMultipleMessages(Queue<Message> messages)
    {
      while (messages.Count > 0)
      {
         var message = messages.Dequeue();
         // do something with message, and once you're done it is
         // probably eligible for garbage collection because it is
         // no longer in the Queue
      }
    
      Task.Factory.StartNew(() =>
            {
                //very time demanding task
                _sendRequestHandler.SendMultipleMessages(BatchId);
            });
    
     return BatchId;
    }
