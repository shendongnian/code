    class FirstRequestInitialisation
    {
    	private static string host = null;
    
    	private static Object s_lock = new Object();
    
    	// Initialise only on the first request
    	public static void Initialise(HttpContext context)
    	{
    		if (string.IsNullOrEmpty(host))
    		{ //host isn't set so this is first request
    			lock (s_lock)
    			{ //no race condition
    				if (string.IsNullOrEmpty(host))
    				{
    					Uri uri = HttpContext.Current.Request.Url;
    					host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
    
    					//open EscalationThread class constructor that starts anonymous thread that keeps running. 
    					//Constructor saves host into a property to remember and use it.
    					EscalationThread et = new EscalationThread(host);
    				}
    			}
    		}
    	}
    }
