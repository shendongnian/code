    class RedirectResultNoBody : ActionResult
    {
    	public override void ExecuteResult(ControllerContext context) 
    	{
    		var response = context.HttpContext.Response;
    		response.StatusCode = 301;
    		response.RedirectLocation = "yourredirect";
    		response.End();
    	}
    }
