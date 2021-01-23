    public class AuthorizeAttribute
    {
        protected bool RequireIdClaim { get; private set; }
	    public AuthorizeAttribute(bool requireIdClaim = false)
	    {
	    	RequireIdClaim = requireIdClaim;
        }
        public Authorize() 
        {
            //regular auth stuff here
            if (RequireIdClaim)
            {
                var routeData = context.ActionContext.Request.GetRouteData();
	            var requiredIdClaim = Convert.ToInt32(routeData.Values["id"]); 
                //Check here if their user profile has a claim to that Id
            }
        }
    }
