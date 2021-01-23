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
    
    	public class MyRequest
    	{
    		public string Name { get; set; }
    		public int Age { get; set; }
    	}
    
    	public class MyResponse
    	{
    		public string Name { get; set; }
    		public int Age { get; set; }
    	}
    }
