    interface IMessageHandler
    {
    	bool ProcessMessage(Message m);
    }
    
    class MessageHandler<T>: IMessageHandler where T:Message
    {
    	Func<T, bool> handlerDelegate;
    	
    	public MessageHandler(Func<T, bool> handlerDelegate)
    	{
    		this.handlerDelegate = handlerDelegate;	
    	}
    
    	public bool ProcessMessage(Message m)
    	{
    		handlerDelegate((T)m);	
    	}
    }
