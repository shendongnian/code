    public class MyWebService
    {
      private static readonly string _serviceUrl = ConfigurationManager.AppSettings["serviceUrl"] ?? "http://someserviceurl.com/service.asmx";
      public MyWebService()
      {
      }
      private WebServiceClient GetClient()
      {
        WebServiceClient client = new WebServiceClient();
        client.Url = _serviceUrl;
        return client;
      }
      private void Method1()
      {
        var client = GetClient();
        // do stuff
      }
    }
