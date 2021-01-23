    public class ValuesController : ApiController
        {
    
        // GET api/values/5
        public string Get(string id)
        {
            if (id == "large")
            {
                return "large value";
            }
            if (id == "small")
            {
                return "small value";
            }
            return "value " + id;
        }
    }
