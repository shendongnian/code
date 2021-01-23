    // GET api/Users/5
    [HttpGet, ActionName("Default")]
    public User GetUser(int id) // THIS STILL DOES NOT WORK
    // GET api/Users/5/UserGroups
    [HttpGet, ActionName("usergroups")]
    public IEnumerable<UserGroup> GetUserGroups(int id) // THIS WORKS
    // ROUTES
    config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "{controller}/{id}/{action}",
        defaults: new { id = RouteParameter.Optional,
     action = "Default" }
    );
