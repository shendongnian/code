    using System.Runtime.Serialization;
    using System.Web.Http;
    
    namespace webAPI_Test.Controllers
    {
    	public class ValuesController : ApiController
    	{
    		// POST api/values
    		public MyResponse Post([FromBody] MyRequest value)
    		{
    			var response = new MyResponse();
    			response.Name = value.Name;
    			response.Age = value.Age;
    			return response;
    		}
    	}
    
    	[DataContract(Namespace = "")]
    	public class MyRequest
    	{
    		[DataMember(Order = 1)]
    		public string Name { get; set; }
    
    		[DataMember(Order = 2)]
    		public int Age { get; set; }
    	}
    
    	[DataContract(Namespace = "")]
    	public class MyResponse
    	{
    		[DataMember]
    		public string Name { get; set; }
    
    		[DataMember]
    		public int Age { get; set; }
    	}
    }
