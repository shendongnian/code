    Response.ContentType = "text/event-stream";
    while (Response.IsClientConnected)
    {
       if(thereIsAMessage)
       {
           Response.Write(message);
           Response.Flush();
       }
    
       System.Threading.Thread.Sleep(1000);
    }
