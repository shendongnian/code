    internal class Program
    {
       private static void Main(string[] args)
       {
        var baseAddress = new Uri("http://oak:8700/");
        var configuration = new HttpSelfHostConfiguration(baseAddress);
        var router = new ApiRouter("api", baseAddress);
        // /api/Contacts
        router.Add("Contacts", rcs => rcs.To<ContactsController>());
        // /api/Contact/{contactid}
        router.Add("Contact", rc =>
                              rc.Add("{contactid}", rci => rci.To<ContactController>()));
        // /api/Group/{groupid}
        // /api/Group/{groupid}/Contacts
        router.Add("Group", rg =>
                            rg.Add("{groupid}", rgi => rgi.To<GroupController>() 
                                                           .Add("Contacts", rgc => rgc.To<GroupContactsController>())));
            
        configuration.MessageHandlers.Add(router);
        var host = new HttpSelfHostServer(configuration);
        host.OpenAsync().Wait();
        Console.WriteLine("Host open.  Hit enter to exit...");
        Console.Read();
        host.CloseAsync().Wait();
      }
    }
    public class GroupController : TestController { }
    public class ContactsController : TestController { }
    public class ContactController : TestController { }
    public class GroupContactsController : TestController { }
    
    
    public class TestController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var pathRouteData = (PathRouteData) Request.GetRouteData();
    
            var paramvalues = new StringBuilder();
    
            foreach (KeyValuePair<string, object> keyValuePair in pathRouteData.Values)
            {
                paramvalues.Append(keyValuePair.Key);
                paramvalues.Append(" = ");
                paramvalues.Append(keyValuePair.Value);
                paramvalues.Append(Environment.NewLine);
            }
    
            var url = pathRouteData.RootRouter.GetUrlForController(this.GetType());
    
            return new HttpResponseMessage()
                       {
                           Content = new StringContent("Response from " + this.GetType().Name + Environment.NewLine
                                                       + "Url: " + url.AbsoluteUri
                                                       + "Parameters: " + Environment.NewLine
                                                       + paramvalues.ToString())
                       };
        }
    }
