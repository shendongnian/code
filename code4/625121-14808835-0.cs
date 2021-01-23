    public class MSMQueue:IQueue
        {
    
            public MSMQueue(string queueName)
            {
                Message_Queue = queueName;
            }
    
            public string Message_Queue { get; private set; }
    
            public string Pop()
            {
                MessageQueue queue = new MessageQueue(Message_Queue);
    
                if (queue.Transactional)
                    return popTransactionalQueue(queue, new TimeSpan(0, 0, 1));
                else
                    return popNormalQueue(queue, new TimeSpan(0, 0, 1));
            }
    
            public string Pop(TimeSpan timeSpan)
            {
                MessageQueue myQueue = new MessageQueue(Message_Queue);
    
                if (myQueue.Transactional)
                    return popTransactionalQueue(myQueue, timeSpan);
                else
                    return popNormalQueue(myQueue, timeSpan);
            }
    
            public void Add(string message)
            {
                // Connect to a queue on the local computer.
                MessageQueue myQueue = new MessageQueue(Message_Queue);
    
                // Send a message to the queue.
                if (myQueue.Transactional)
                {
                    var myTransaction = new MessageQueueTransaction();
                    myTransaction.Begin();
                    myQueue.Send(message, myTransaction);
                    myTransaction.Commit();
                }
                else
                    myQueue.Send(message);
            }
    
            #region private methods
    
            private string popNormalQueue(MessageQueue queue, TimeSpan timeOut)
            {
                var message = queue.Receive(timeOut);
                message.Formatter = new XmlMessageFormatter(
                                    new String[] { "System.String,mscorlib" });
                return message.Body.ToString();
            }
    
            private string popTransactionalQueue(MessageQueue queue, TimeSpan timeOut)
            {
    
                // Set the formatter.
                queue.Formatter = new XmlMessageFormatter(new Type[]
                    {typeof(String)});
                
                // Create a transaction.
                MessageQueueTransaction myTransaction = new 
                    MessageQueueTransaction();
    
                String message=string.Empty;
    
                try
                {
                    myTransaction.Begin();
    
                    Message myMessage = queue.Receive(timeOut, myTransaction); 
                    message = (String)myMessage.Body;
    
                    myTransaction.Commit();
    
                }
                
                catch (MessageQueueException e)
                {
                    myTransaction.Abort();
                    throw e;
                }
    
                return message;
            }
    
            #endregion
        }
