    public class DocumentsController : ApiController
    {
    	public HttpResponseMessage Get()
    	{
    		ClassFromOtherAssembly.GetDocuments(); //this is Service locator
    		//really bad for testability and maintenance
    		...
    	}
    }
