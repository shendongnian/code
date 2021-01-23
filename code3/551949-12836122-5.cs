    public class PostController : Controller 
    {
        [HttpParamAction]
        [HttpPost]
        public ActionResult SaveDraft(...) 
        {
            // ...
        }
    
        [HttpParamAction]
        [HttpPost]
        public ActionResult Publish(...) 
        {
            // ...
        }
    }
