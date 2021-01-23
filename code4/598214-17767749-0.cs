    using System.Web.Http;
    namespace webAPIExample.Controllers
    {
    	public class ValuesController : ApiController
    	{
    		public TestModelOutput Post(TestModelInput input)
    		{
    			var response = new TestModelOutput();
    			response.Name = input.Name;
    			response.Age = input.Age;
    			return response;
    		}
    
    		public class TestModelInput
    		{
    			public string Name { get; set; }
    			public int Age { get; set; }
    		}
    
    		public class TestModelOutput
    		{
    			public string Name { get; set; }
    			public int Age { get; set; }
    		}
    	}
    }
