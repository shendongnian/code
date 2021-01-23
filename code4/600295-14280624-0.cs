    using (System.Messaging.MessageQueue queue
        = QueueFactory.Instance.BuildQueue(this.Path))
    {
        System.Messaging.Message message = new System.Messaging.Message
        {
            Body = body,
            Formatter = new BinaryMessageFormatter(),
            TimeToBeReceived = this.ExpirationMinutes
        };
        MessageQueueTransaction transaction = new MessageQueueTransaction();
        try
        {
            transaction.Begin();
            queue.Send(message, label, transaction);
            transaction.Commit();
        }
        catch(System.Exception e)
        {
            transaction.Abort();
            throw e;
        }
        finally
        {
            transaction.Dispose();
        }
    }
