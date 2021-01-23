	String controller = String.Empty;
	if (ViewContext.RouteData.Values.ContainsKey("controller")) {
		controller = (String)ViewContext.RouteData.Values["controller"];
	}
	String action = String.Empty;
	if (ViewContext.RouteData.Values.ContainsKey("action")) {
		action = (String)ViewContext.RouteData.Values["action"];
	}
	String area = String.Empty;
	if (ViewContext.RouteData.DataTokens.ContainsKey("area")) {
		area = (String)ViewContext.RouteData.DataTokens["area"];
	}
