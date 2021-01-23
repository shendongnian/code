    public class DocumentsController : ApiController
    {
    	private IDocumentProvider;
    	
    	public DocumentsController(IDocumentProvider provider)
    	{
    		this.provider = provider;
    	}
    	
    	public HttpResponseMessage Get()
    	{
    		provider.GetDocuments(); //this is DI
    		...
    	}
    }
