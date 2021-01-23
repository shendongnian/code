    public class MyService : IMyService
    {
            public string Test(string text)
            {
                return text; // whatever
            }
    
    }
    
    [ServiceContractAttribute(Namespace="http://schemas.myservice.com")]
    public interface IMyService
    {
        [OperationContractAttribute]
        [WebInvokeAttribute(UriTemplate="Test", // change this accordingly
         ResponseFormat=WebMessageFormat.Json, // change this accordingly
         RequestFormat=WebMessageFormat.Json, // change this accordingly
         BodyStyle=Wrapped)]
        string Test(string text);
    }
