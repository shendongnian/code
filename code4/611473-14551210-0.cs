    public class Adapter{
     public void processRequest(){
       RequestProcessor processor = new RequestProcessor();
       processor.processRequest();
     }
    }
    public class RequestProcessor{
      public void procesRequest(){
        Irequest request = new HTTPRequest();
        HTTPService service = new HTTPService();
        // fetch the uri from builder class
        URI url = URIBUIlder();
        string response = service.sendRequest(request,url);
        // now fetch type from just 
        Type t = Serializer.searialize<T>(response);
      }
    }
    public Class Serializer{
      public static  T searialize<T>(string xml){
      }
    }
    
    public interface IRequest{
     public string sendRequest(uri url);
    }
    
    public class HTTPRequest:IRequest{
     public string sendRequest(uri url){
      // instantiate actual http request here and return response
     }
    }
   
    //This will act as controller
    public class HTTPService{
     public string sendRequest(IRequest request,uri url) {
      return request.sendRequest(url);
     }
    }
