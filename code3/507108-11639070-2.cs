    public sealed class RedirectResultNoBody : ActionResult
    {
    	private readonly string location;
    	public RedirectResultNoBody(string location) 
    	{
    		this.location = location;
    	}
    	public override void ExecuteResult(ControllerContext context) 
    	{
    		var response = context.HttpContext.Response;
    		response.StatusCode = 302;
    		response.RedirectLocation = location;
    		response.End();
    	}
    }
