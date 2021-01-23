    public class MessageListener
    {
    	private readonly IObservable<IMessage> _messages;
    	private readonly IScheduler _scheduler;
    	
    	public MessageListener()
    	{
    		_scheduler = new EventLoopScheduler();
    		
    		var messages = ListenToMessages()
    									.SubscribeOn(_scheduler)
    									.Publish();
    									
    		_messages = messages;
    		messages.Connect();
    	}
    	
    	public IObservable<IMessage> Messages
    	{
    		get {return _messages;}
    	}
    
    	private IObservable<IMessage> ListenToMessages()
    	{
    		return Observable.Create<IMessage>(o=>
    		{
    				return _scheduler.Schedule(recurse=>
    				{
    					try
    					{	        
    						var messages = GetMessages();
    						foreach (var msg in messages)
    						{
    							o.OnNext(msg);
    						}	
    						recurse();
    					}
    					catch (Exception ex)
    					{
    						o.OnError(ex);
    					}					
    				});
    		});
    	}
        private IEnumerable<IMessage> GetMessages()
        {
             //Do some work here that gets messages from a queue, 
             // file system, database or other system that cant push 
             // new data at us.
             // 
             //This may return an empty result when no new data is found.
        }
    }
