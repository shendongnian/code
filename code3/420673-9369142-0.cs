    public static MvcHtmlString DebugReleaseString(this System.Web.Mvc.HtmlHelper html, string debugString, string releaseString)
	{
		string toReturn = debugString;
    #if !DEBUG
		if (!string.IsNullOrEmpty(releaseString))
			toReturn = releaseString;
    #endif
		return MvcHtmlString.Create(toReturn);
	}
