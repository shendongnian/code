        public static class RequestExtensions {
            public static ActionResult RedirectReturnUrlOrDefaultAction(this Request, Action<string> returnAction,Action defaultAction)
    {        
       if( string.IsNullOrEmpty(request.QueryString["returnURL"]) )
       {
           returnAction(request.QueryString["returnURL"]));
        }
        else
        {
            defaultAction();
         }
    }
