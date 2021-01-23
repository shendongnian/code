    public class MyRouteConstraint : IRouteConstraint
    {
      public readonly IList<string> KnownActions = new List<string> 
           { "Send", "Find", ... }; // explicit action names
    
      public bool Match(System.Web.HttpContextBase httpContext, Route route
                      , string parameterName, RouteValueDictionary values
                      , RouteDirection routeDirection)
      {
        // for now skip the Url generation
        if (routeDirection.Equals(RouteDirection.UrlGeneration))
        {
          return false; // leave it on default
        }
    
        // try to find out our parameters
        string action = values["action"].ToString();
        string id = values["id"].ToString();
    
        // id and action were provided?
        var bothProvided = !(string.IsNullOrEmpty(action) || string.IsNullOrEmpty(id));
        if (bothProvided)
        {
          return false; // leave it on default
        }
    
        var isKnownAction = KnownActions.Contains(action
                               , StringComparer.InvariantCultureIgnoreCase);
    
        // action is known
        if (isKnownAction)
        {
          return false; // leave it on default
        }
    
        // action is not known, id was found
        values["action"] = "Index"; // change action
        values["id"] = action; // use the id
    
        return true;
      }
