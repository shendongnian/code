    private static readonly object ResourceLock = new object();
  
    public static MvcHtmlString SerializeGlobalResources(this HtmlHelper helper)
    {
        lock (ResourceLock)
        {
            // Existing code goes here ....
        }
    }
    
