    //Some class class to start up the REST web service
    public class someClass(){
    	public static void runRESTWebservice(){
    		webserviceHost = new WebServiceHost(typeof(Service1), new Uri("http://localhost:8080));
    		webserviceHost.AddServiceEndpoint(typeof(IService), getBinding(), "webservice").Behaviors.Add(new WebHttpBehavior());
    		webserviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
    	}
	
        //produces a custom web service binding mapped to the obtained gzip classes
    	private static Binding getBinding(){
    		CustomBinding customBinding = new CustomBinding(new WebHttpBinding());
    		for (int i = 0; i < customBinding.Elements.Count; i++)
    		{
    			if (customBinding.Elements[i] is WebMessageEncodingBindingElement)
    			{
    				WebMessageEncodingBindingElement webBE = (WebMessageEncodingBindingElement)customBinding.Elements[i];
    				webBE.ContentTypeMapper = new MyMapper();
    				customBinding.Elements[i] = new GZipMessageEncodingBindingElement(webBE);
    			}
    			else if (customBinding.Elements[i] is TransportBindingElement)
    			{
    				((TransportBindingElement)customBinding.Elements[i]).MaxReceivedMessageSize = int.MaxValue;
    			}
    		}
    		return customBinding;
    	}
    }
    //mapper class to match json responses
    public class MyMapper : WebContentTypeMapper{
    	public override WebContentFormat GetMessageFormatForContentType(string contentType){
    		return WebContentFormat.Json;
    	}
    }
    //Define a service contract interface plus methods that returns JSON responses
    [ServiceContract]
    public interface IService{
    	[WebGet(UriTemplate = "somedata", ResponseFormat = WebMessageFormat.Json)]
    	string getSomeData();
    }
    //In your class that implements the contract explicitly set the encoding of the response in the methods you implement
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService
    {
    	public string getSomeData()
    	{
    		WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.ContentEncoding] = "gzip";
    		return "some data";
    	}
    }
