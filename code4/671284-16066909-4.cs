    public class UserSettingsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAll();
        [HttpGet]
        public HttpResponseMessage Get(string key);
        [HttpGet]
        public HttpResponseMessage Set(string key, string value);
        [HttpGet]
        public HttpResponseMessage Restore(string key);
    }
