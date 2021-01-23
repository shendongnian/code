    public class PermanentRedirectResult : ActionResult
    {
        public string Url { get; private set; }
    
        public PermanentRedirectResult(string url)
        {
            this.Url = url;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = 301;
            response.Status = "301 Moved Permanently";
            response.RedirectLocation = Url;
            response.End();
        }
    }
