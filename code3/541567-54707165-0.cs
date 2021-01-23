    class HttpInterface
    {
     // https://docs.microsoft.com/en-us/azure/architecture/antipatterns/improper-instantiation/#how-to-fix-the-problem
     // https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient#remarks
     private static readonly HttpClient client;
     // static initialize
     static IXOSInterface()
     {
      // choose one of these depending on your framework
      
      // HttpClientHandler is an HttpMessageHandler with a common set of properties
      var handler = new HttpClientHandler();
      {
          ServerCertificateCustomValidationCallback = delegate { return true; },
      };
      // derives from HttpClientHandler but adds properties that generally only are available on full .NET
      var handler = new WebRequestHandler()
      {
          ServerCertificateValidationCallback = delegate { return true; },
          ServerCertificateCustomValidationCallback = delegate { return true; },
      };
      client = new HttpClient(handler);
     }
     
     .....
     
     // in your code use the static client to do your stuff
     var jsonEncoded = new StringContent(someJsonString, Encoding.UTF8, "application/json");
     // here in sync
     using (HttpResponseMessage resultMsg = client.PostAsync(someRequestUrl, jsonEncoded).Result)
     {
      using (HttpContent respContent = resultMsg.Content)
      {
       return respContent.ReadAsStringAsync().Result;
      }
     }
    }
