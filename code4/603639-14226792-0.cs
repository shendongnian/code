    public class HttpNotFoundResult : HttpStatusCodeResult
    {
        public HttpNotFoundResult() : this(null)
        {
        }
    
        public HttpNotFoundResult(string statusDescription) : 
               base(HttpStatusCode.NotFound, statusDescription)
        {
        }
    }
