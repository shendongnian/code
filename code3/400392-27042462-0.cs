    public static void SetUpReferrerRouteVariables(HttpRequestBase httpRequestBase, ref string previousAreaName, ref string previousControllerName, ref string previousActionName)
	{
        // No referrer found, perhaps page accessed directly, just return.
		if (httpRequestBase.UrlReferrer == null) return;
		// Split the url to url + QueryString.
		var fullUrl = httpRequestBase.UrlReferrer.ToString();
		var questionMarkIndex = fullUrl.IndexOf('?');
		string queryString = null;
		var url = fullUrl;
		if (questionMarkIndex != -1) // There is a QueryString
		{
			url = fullUrl.Substring(0, questionMarkIndex);
			queryString = fullUrl.Substring(questionMarkIndex + 1);
		}
		// Arrange.
		var request = new HttpRequest(null, url, queryString);
		var response = new HttpResponse(new StringWriter());
		var httpContext = new HttpContext(request, response);
		var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
		if (routeData == null) throw new AuthenticationRedirectToReferrerDataNotFoundException();
		// Extract the data.
		var previousValues = routeData.Values;
		previousAreaName = previousValues["area"] == null ? string.Empty : previousValues["area"].ToString();
		previousControllerName = previousValues["controller"] == null ? string.Empty : previousValues["controller"].ToString();
		previousActionName = previousValues["action"] == null ? string.Empty : previousValues["action"].ToString();
		if (previousActionName != string.Empty) return;
		var routeDataAsListFromMsDirectRouteMatches = (List<RouteData>)previousValues["MS_DirectRouteMatches"];
		var routeValueDictionaryFromMsDirectRouteMatches = routeDataAsListFromMsDirectRouteMatches.FirstOrDefault();
		if (routeValueDictionaryFromMsDirectRouteMatches == null) return;
		previousActionName = routeValueDictionaryFromMsDirectRouteMatches.Values["action"].ToString();
		if (previousActionName == "") previousActionName = "Index";
    }
