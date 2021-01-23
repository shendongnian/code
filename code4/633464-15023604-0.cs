    public class ProductController : ApiController
    {
        public HttpResponseMessage Create(int id)
        {
            var uri = Url.Link("Foo", new { id = id, controller = "product" });
            return Request.CreateResponse(HttpStatusCode.OK, uri);
        }
    }
