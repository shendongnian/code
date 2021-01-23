    public class HttpUnauthorizedResult : HttpStatusCodeResult
    {
        public HttpUnauthorizedResult() : this(null)
        {
        }
    
        public HttpUnauthorizedResult(string statusDescription) : 
               base(HttpStatusCode.Unauthorized, statusDescription)
        {
        }
    }
