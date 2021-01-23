	public static string GetAreaName(this RouteData routeData)
	{
		object value;
		if (routeData.DataTokens.TryGetValue("area", out value))
		{
			return (value as string);
		}
		return GetAreaName(routeData.Route);
	}
	public static string GetAreaName(this RouteBase route)
	{
		var areRoute = route as IRouteWithArea;
		if (areRoute != null)
		{
			return areRoute.Area;
		}
		
		var standardRoute = route as Route;
		if ((standardRoute != null) && (standardRoute.DataTokens != null))
		{
			return (standardRoute.DataTokens["area"] as string) ?? string.Empty;
		}
		
		return string.Empty;
	}
