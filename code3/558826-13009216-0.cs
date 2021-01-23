    protected virtual bool ProcessConstraint(HttpContextBase httpContext, object constraint, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    {
    	IRouteConstraint routeConstraint = constraint as IRouteConstraint;
    	// checks custom constraint class instances
    	if (routeConstraint != null)
    	{
    		return routeConstraint.Match(httpContext, this, parameterName, values, routeDirection);
    	}
    	// No? Ok constraint provided as regular expression string then?
    	string text = constraint as string;
    	if (text == null)
    	{
    		throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, SR.GetString("Route_ValidationMustBeStringOrCustomConstraint"), new object[]
    		{
    			parameterName,
    			this.Url
    		}));
    	}
    	object value;
    	values.TryGetValue(parameterName, out value);
    	string input = Convert.ToString(value, CultureInfo.InvariantCulture);
    	string pattern = "^(" + text + ")$";
    	// LOOK AT THIS LINE
    	return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
    }
