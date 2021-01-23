    public bool SubscribeEvent(string eventName, string handlerMethodName, 
        object objectOnWhichTheEventIsDefined, 
        object objectOnWhichTheEventHandlerIsDefined)
    {
        try
        {
            // Determine meta data from event and handler
            var eventInfo = objectOnWhichTheEventIsDefined.GetType().GetEvent(eventName);
            var methodInfo = objectOnWhichTheEventHandlerIsDefined.GetType().
            GetMethod(handlerMethodName);
            
            // Create new delegate mapping event to handler
            Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, objectOnWhichTheEventHandlerIsDefined, methodInfo);
            eventInfo.AddEventHandler(objectOnWhichTheEventIsDefined, handler);
            return true;
        }
        catch (Exception ex)
        {
            // Log failure!
            var message = "Exception while subscribing to handler. Event:" + eventName + " - Handler: " + handlerMethodName + "- Exception: " + ex;
            Debug.Print(message);
            return false;
        }
    }
