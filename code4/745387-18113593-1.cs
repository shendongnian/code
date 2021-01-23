    private Dictionary<Type, IMessageHandler> listeners;
    
    public void AddListener<T>(Func<T, bool> listener) where T : Message 
    { 
        this.listeners[typeof(T)].Add(new MessageHandler<T>(listener));
    }
    
    public void SendMessage(Message message) 
    {
        foreach (IMessageHandler listener in this.listeners[message.GetType()]) 
    	{
           listener.ProcessMessage(message);
        }
    }
