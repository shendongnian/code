    public class HttpBadRequestResult : HttpStatusCodeResult
    {
        public HttpBadRequestResult() : this(null)
        {
        }
    
        public HttpBadRequestResult(string statusDescription) : 
               base(HttpStatusCode.BadRequest, statusDescription)
        {
        }
    }
