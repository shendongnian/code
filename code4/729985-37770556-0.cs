    public class ParentController : ApiController
    {
        public IHttpActionResult Foo()
        {
           ChildRepository.Foo();
           return Ok(...);
        }
    }
    
    public class ChildRepository : ApiController
    {
        public HttpResponseMessage Foo()
        {
            // Do something
            return Request.CreateResponse(...);
        }
    }
