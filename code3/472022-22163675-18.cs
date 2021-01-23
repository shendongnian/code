	public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
			var exception = context.Exception as WebException;
			if (exception != null) {
				context.Response = context.Request.CreateErrorResponse(exception.StatusCode, exception.Message);
			}
		}
	}
