    public string Messages { get; set; } // declare "Messages"
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
         Messages = "bla bla";// Or set in controller
         ....
         ....
         ....
         ....
         base.AuthorizeCore(httpContext); 
    }
    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
       Messages.ToString(); // Read Message ="bla bla"
       base.HandleUnauthorizedRequest(filterContext);
    }
