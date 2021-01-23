    class OverrideableHttpMethodConstraint : HttpMethodConstraint
    {
        public OverrideableHttpMethodConstraint(HttpMethod httpMethod) : base(httpMethod)
        {
        }
        protected override bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            IEnumerable<string> headerValues;
            if (request.Method.Method.Equals("POST", StringComparison.OrdinalIgnoreCase) && 
                request.Headers.TryGetValues("X-HTTP-Method-Override", out headerValues))
            {
                var method = headerValues.FirstOrDefault();
                if (method != null)
                {
                    request.Method = new HttpMethod(method);
                }
            }
            return base.Match(request, route, parameterName, values, routeDirection);
        }
    }
