    public interface IWebRequestHandler
    {
    WebRequest GetRequest (string URI);
    }
    
    public class WebRequestHandler : IWebRequestHandler
    {
    public WebRequest GetRequest (string URI)
    {
    return WebRequest.Create(URl);
    }
    } 
