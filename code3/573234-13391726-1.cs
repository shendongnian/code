    public class MyRouteConstraint : IRouteConstraint
    {
        public bool Match(System.Web.HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // for now skip the Url generation
            if (routeDirection.Equals(RouteDirection.UrlGeneration))
            {
                return false;
            }
    
            // try to find out our parameters
            object theId1 = null;
            object theId2 = null;
    
            var parametersExist = values.TryGetValue("theId1", out theId1)
                                && values.TryGetValue("theId2", out theId2);
    
            // not our case
            if( ! parametersExist)
            {
                return false;
            }
    
            // first argument re-inserted
            values["id1"] = theId1;
            values["id3"] = theId1;
            // TODO add other, remove theId1
    
            // second argument re-inserted
            values["id2"] = theId2;
            values["id4"] = theId2;
            // TODO add other, remove theId2
    
                
            return true;
        }
    }
