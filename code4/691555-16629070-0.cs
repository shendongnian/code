    public class PermanentRedirectResult : ActionResult
    {
        public string Url { get; private set; }
    
        public PermanentRedirectResult(string url)
        {
            this.Url = url;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = 301;
            context.Response.Status = "301 Moved Permanently";
            context.HttpContext.Response.RedirectLocation = Url;
            context.HttpContext.Response.End();
        }
    }
