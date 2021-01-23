    public class FooController : ApiController
    {
    	[ResponseType(typeof(Bar))]
        public HttpResponseMessage Get(string id)
    	{
    		// ...
    	}
    }
