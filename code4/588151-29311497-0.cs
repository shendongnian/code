    public class YourController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post()
        {
            string bodyText = this.Request.Content.ReadAsStringAsync().Result;
            //more code here...
        }
    }
