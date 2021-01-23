    public class TextActionResult : ActionResult
    {
        readonly string _response;
    
        public TextActionResult() { }
    
        public TextActionResult(string response)
        {
            _response = response;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = "text/html";  //text/plain?
            context.HttpContext.Response.Write(_response);
            //you may want further tweaks here
            }
    }
