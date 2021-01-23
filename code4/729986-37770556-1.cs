    public class ParentController : ApiController
        {
            public IHttpActionResult Foo()
            {
               ChildRepository.Foo(Request);
               return Ok(...);
            }
        }
        
        public class ChildRepository
        {
            public HttpResponseMessage Foo(HttpRequestMessage request)
            {
                // Do something
                return request.CreateResponse(...);
            }
        }
