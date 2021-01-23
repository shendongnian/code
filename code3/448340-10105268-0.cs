    interface ISendNotificationHandler
    {
    	Type ActionType { get; }
    	void SendNotification(object action)
    }  
    
    class Action1SendNotificationHandler : ISendNotificationHandler
    {
    	public Type ActionType {get{return typeof(Action1);}}
    	public void SendNotification(object action)
    	{
    		Action1 a = (Action1)action;
    		// TODO: send notification
    	}	
    }
    
    // your method originally posted 
    public void SendNotification(Object action)     
    {
    		var handlers = new ISendNotificationHandler[]{ new Action1SendNotificationHandler(), /* etc*/}
    		
    		// 
    		var handler = handlers.FirstOrDefault(h=>action.GetType().IsSubclassOf(h.ActionType))
    		if(handler != null)
    		{
    			handler.SendNotification(action);
    		}
    		else
    		{
    			throw new Exception("Handler not found for action " + action);
    		}
    } 
