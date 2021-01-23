    public interface IHttpContext
    {
        void AppendToResponseLog(/*parmas go here*/);
    }
    public class HttpContextWrapper : IHttpContext
    {
        private HttpContext _httpContext = HttpContext.Current; //or constructor param
        public void AppendToResponseLog(/*parmas go here*/)
        {
            _httpContext.Response.AppendToLog(/*params*/);
        }  
    }
