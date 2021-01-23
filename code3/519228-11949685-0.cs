    routes.MapHttpRoute(
        name: "ActionApi",
        routeTemplate: "api/{controller}/{action}",
        defaults: new { id = RouteParameter.Optional }
    );
    public class CampaignsController : ApiController
    {
        [HttpPost]
        public void send();
        [HttpPost]
        public void schedule(DateDto date);
    }
