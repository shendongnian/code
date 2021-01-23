    public class Sender
    {
    public IWebRequestHandler Handler{get;set;}
    public void Send(string Message)
    {
    Handler.GetRequest(new URI(Message));//call the method with right params, just an example
    }
    }
