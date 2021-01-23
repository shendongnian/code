    var client = new RestClient();
    client.Authenticator = new YourAuthenticator(); // implements IAuthenticator
    
    public interface IAuthenticator
    {
        void Authenticate(IRestClient client, IRestRequest request);
    }
    internal class YourAuthenticator: IAuthenticator
    {
      public void Authenticate(IRestClient client, IRestRequest request)
      {
        // log request
      }
    }
