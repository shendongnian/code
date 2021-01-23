    [RoutePrefix("api/VTRouting")]
    public class VTRoutingController : ApiController
    {
        [HttpPost]
        [Route("Route")]
        public MyResult Route(MyRequestTemplate routingRequestTemplate)
        {
            return null;
        }
        [HttpPost]
        [Route("TSPRoute")]
        public MyResult TSPRoute(MyRequestTemplate routingRequestTemplate)
        {
            return null;
        }
    }
