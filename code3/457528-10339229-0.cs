    while (!notDone)// or use a timer or periodic task of some sort...
    {
        try
        {
            using (MessageQueue queue = new MessageQueue(queuePath))
            {
                Message message = queue.Receive(TimeSpan.FromMilliseconds(500));
             
                // process message
            }
        }
        catch (MessageQueueException ex)
        {
            // handle exceptions
        }
    }
