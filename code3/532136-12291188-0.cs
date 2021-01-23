    public bool Subscribe(string type, Action callback)
    {
        bool IsSubscribed = false;
        try
        {
            switch (type)
            {
                case "Elements":
                {
                    logger.Info("Subscribing toPublisher");
                    Subscriber.SubscribeToElements((e,t) => ElementResponse(e,t,callback));
                    logger.Info("Subscription Completed");
                    IsSubscribed = true;
                    break;
                }
            }
        }    
        catch (Exception ex)
        {
            logger.Error(ex);
        }
    
        return IsSubscribed;
    }
    
    public void ElementResponse(Element element, SubscriptionEvent.ActionType eventActionType, Action callback)
    {
        try
        {
            //  stuff to Do
            callback();
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
    }
