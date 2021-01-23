    public class WebSocketServer
    {
    	private WebSocketMessageHandler messageHander;
    
    	// Incoming message handlers
    	private Dictionary<string, System.Delegate> ProcessHandlers = new Dictionary<string, System.Delegate>();
    	
    	public void RegisterProcessHandler(string name, System.Delegate handler)
    	{
    		ProcessHandlers.Add(name, handler);
    	}
    	
    	public void processRequest(API.Request request)
    	{
    		String resquestType = request.GetType().Name;
    		String processorName = resquestType.Substring(0, resquestType.Length - 2);
    		API.Response response = null;
    				
    		string processorName = "Process" + processorName;
    		
    		if (ProcessHandlers.ContainsKey(processorName))
    		{
    			System.Delegate myDelegate = ProcessHandlers[processorName]; 
    			response = (API.Response)myDelegate.DynamicInvoke(request);
    		}
    		else
    		{
    			logger.Warn("Failed to find a processor for " + processorName);
    			response = new ErrorRs(request.id, "Failed to find a processor for " + processorName);
    		}
    		
    		sendResponse(response, request);
    	}
    }
