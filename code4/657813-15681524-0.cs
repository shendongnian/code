        public class GuidConstraint : IHttpRouteConstraint
        {
            public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
                              HttpRouteDirection routeDirection)
            {
                if (values.ContainsKey(parameterName))
                {
                    string stringValue = values[parameterName] as string;
    
                    if (!string.IsNullOrEmpty(stringValue))
                    {
                        Guid guidValue;
    
                        return Guid.TryParse(stringValue, out guidValue) && (guidValue != Guid.Empty);
                    }
                }
    
                return false;
            }
        }
