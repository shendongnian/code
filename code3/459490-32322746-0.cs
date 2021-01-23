    public class AssetsController : Controller
    {
        protected void SetMIME(string mimeType)
        {
            this.Response.AddHeader("Content-Type", mimeType);
            this.Response.ContentType = mimeType;
        }
    
        // this will render a view as a Javascript file
        public ActionResult GlobalJS()
        {
            this.SetMIME("text/javascript");
            return PartialView();
        }
    }
