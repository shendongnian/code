    public void getAllOutputQueueMessages()
    {
        try
        {
            return queue_.GetAllMessages();
        }
        catch (Exception)
        {
            queue_ = OpenQueue();
            return queue_.GetAllMessages();
        }
    }
