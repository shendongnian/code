    public class AuditController : ApiController
    {
        public String Post([FromBody]String test)
        {
            return "Success : " + test;
        }
    
        public String Get(String test)
        {
            return "Success : " + test;
        }
    }
