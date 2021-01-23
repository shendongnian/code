    	public class ConnectionAbortTokenAttribute : System.Web.Http.Filters.ActionFilterAttribute
	{
		private readonly string _paramName;
		private Timer _timer;
		private CancellationTokenSource _tokenSource;
		private CancellationToken _token;
		public ConnectionAbortTokenAttribute(string paramName)
		{
			_paramName = paramName;
		}
		public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
		{
			object value;
			if (!actionContext.ActionArguments.TryGetValue(_paramName, out value))
			{
				// no args with defined name found
				base.OnActionExecuting(actionContext);
				return;
			}
			var context = HttpContext.Current;
			if (context == null)
			{
				// consider the self-hosting case (?)
				base.OnActionExecuting(actionContext);
				return;
			}
			_tokenSource = new CancellationTokenSource();
			_token = _tokenSource.Token;
			// inject
			actionContext.ActionArguments[_paramName] = _token;
			// stop timer on client disconnect
			_token.Register(() => _timer.Dispose());
			_timer = new Timer
			(
				state =>
				{
					if (!context.Response.IsClientConnected)
					{
						_tokenSource.Cancel();
					}
				}, null, 0, 1000	// check each second. Opts: make configurable; increase/decrease.
			);
			
			base.OnActionExecuting(actionContext);
		}
		/*
		 * Is this guaranteed to be called?
		 * 
		 * 
		 */
		public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
		{
			if(_timer != null)
				_timer.Dispose();
			
			if(_tokenSource != null)
				_tokenSource.Dispose();
			
			base.OnActionExecuted(actionExecutedContext);
		}
	}
