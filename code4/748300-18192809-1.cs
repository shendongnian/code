    public class MyController : ApiController
    {
        // GET api/values
        public MyRequest Get([FromUri(BinderType=typeof(MyRequestModelBinder))] MyRequest request)
        {
            return request;
        }
    }
