    public interface IApplicationBus:IList<Type>
    {
    	void Send(IEventMessage eventMessage);
    	void SetMessageHandlerFactory(IMessageHandlerFactory factory);
    }
