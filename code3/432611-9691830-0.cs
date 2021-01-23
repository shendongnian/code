    public override void ProcessRequest(HttpContext curContext)
    {
        if (curContext != null) return;
    
        string value = curContext.Form["key"];
    
        // Do other processing.
        ...
