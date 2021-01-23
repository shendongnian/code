    public class AjaxAwareRedirectResult : RedirectResult
    {       
        public AjaxAwareRedirectResult(String url)
            : base(url)
        {
        }
       
        public override void ExecuteResult(ControllerContext context)
        {
            if ( context.RequestContext.HttpContext.Request.IsAjaxRequest() )
            {
                String destinationUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);
                JavaScriptResult result = new JavaScriptResult()
                {
                    Script = "window.location='" + destinationUrl + "';"
                };
                result.ExecuteResult(context);
            }
            else
            {
                base.ExecuteResult(context);
            }
        }
    }
