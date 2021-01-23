    [OperationContract] 
    [WebGet] 
    Stream EventSource(); 
    
    // Implementation Example
    Stream EventSource()
    {
       // These 4 lines are optional but can spare you a lot of trouble ;)
       OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
       context.ContentType = "put your desired content type here";
       context.Headers.Clear();
       context.Headers.Add("cache-control", "no-cache");
       return new System.IO.MemoryStream(Encoding.ASCII.GetBytes("Some String you want to return without the WCF serializer interfering.")); 
    }
