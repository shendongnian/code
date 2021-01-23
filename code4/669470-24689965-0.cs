    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        // GET api/values
        // GET api/values?ids=1&ids=2
        [Route("values")]
        public string GetCollection([FromUri] IList<int> ids)
        {
            if (ids == null)
            {
              return "all";
            }
            return "multiple";
        }
    
        // GET api/values/5
        [Route("values/{id:int}")]
        public string GetById(int id)
        {
            return "single";
        }
