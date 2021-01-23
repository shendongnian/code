        public bool RequireSecure = false;
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (RequireSecure && !((Controller)HttpContext.Current.Items["controllerInstance"]).ControllerContext.IsChildAction)
            {
                base.OnAuthorization(filterContext);
            }
        }        
    } 
