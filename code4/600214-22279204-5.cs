    public class TestController : ApiController
    {
        // POST api/test
        public void Post([ModelBinder(typeof(JsonPolyModelBinder))]ICommand command)
        {
            ...
        }
    }
