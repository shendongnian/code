    public class MyActionFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutedContext context)
            {
    
                context.HttpContext.Session.Add("ID", 123123);
    
                int ID = (int)context.HttpContext.Session.Contents["ID"];
                var rd = context.HttpContext.Request.RequestContext.RouteData;
    
                TED _db = new TED();
    
                //if not in DB
                if (_db.Users.Find(ID) == null && rd.GetRequiredString("action") != "NoAccess")
                {
                    RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                    redirectTargetDictionary.Add("action", "NoAccess");
                    redirectTargetDictionary.Add("controller", "Home");
                    redirectTargetDictionary.Add("area", "");
    
                    context.Result = new RedirectToRouteResult(redirectTargetDictionary);
                }
    
                base.OnActionExecuted(context);
            }
        }
