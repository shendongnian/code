	public class MyTrackingActionFilter: ActionFilterAttribute{
		public override OnActionExecuted(ActionExecutedContext filterContext)
		{
			   if(MyGlobalFlags.TrackingRequests){
				//	do stuff
			}
		}
		
		public override OnResultExecuted(ActionExecutedContext filterContext)
		{
			   if(MyGlobalFlags.TrackingRequests){
				//	do stuff
			}
		}
	}
