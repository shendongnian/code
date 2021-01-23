    [OperationContract] 
    [WebGet] 
    Stream EventSource(); 
    
    // Implementation Example
    Stream EventSource()
    {
       // These 4 lines are optional, but I used them to avoid complications
       OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
       context.ContentType = "plain/text";
       context.Headers.Clear();
       context.Headers.Add("cache-control", "no-cache");
       return new System.IO.MemoryStream(Encoding.ASCII.GetBytes("Some String you want to return as unserialized plain text.")); 
    }
