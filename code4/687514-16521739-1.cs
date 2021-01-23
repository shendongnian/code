    private Message MyMethodThatIsCalledInALoop()
    {
       // These could also be params, etc.
       MessageQueue primary = // whatever code to get a reference to your primary queue
       MessageQueue secondary = // whatever code to get a reference to your secondary queue
       Message message = null;
       if (TryReceiveMessage(primary, out message))
       {
           return message;
       }
       if (TryReceiveMessage(secondary, out message))
       {
           return message;
       }
    }
