    public class HttpContextFactory
    {
    	private static HttpContextBase _context;
    	public static HttpContextBase Current {
    		get {
    			if ((_context != null)) {
    				return _context;
    			}
    			if (HttpContext.Current == null) {
    				throw new InvalidOperationException("HttpContext not available");
    			}
    
    			return new HttpContextWrapper(HttpContext.Current);
    		}
    	}
    
    	public static void SetContext(HttpContextBase context)
    	{
    		_context = context;
    	}
    }
