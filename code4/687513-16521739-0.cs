    private const int ReceiveTimeout = xxxx;
    
    private bool TryReceiveMessage(MessageQueue queue, out Message message)
    {   
        try
        {
            message = queue.Receive(ReceiveTimeout);
            // if we made it here, we are good and have a message
            return true;
        }
        catch(MessageQueueException ex)
        {
            if (MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
            {
                 // this is not exceptional to us, so just return false
                 return false;
            }
    
            // Throw anything else as it is unexpected
            throw;
        }    
    }
