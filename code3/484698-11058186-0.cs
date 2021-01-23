    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        [WebInvoke(
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/DeleteFromService",
            Method = "DELETE")]
        void Delete(int id);
    }
    
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MyService : IMyService
    {
        public void Delete(int id)
        {
            // wrap here the call to your external service
            // simulate a long process
            Thread.Sleep(5000);
        }
    }
