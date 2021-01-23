	public static MvcHtmlString JavascriptTag(this System.Web.Mvc.HtmlHelper html, string fileName)
	{
		return html.JavascriptTag(fileName, string.Empty);
	}
	public static MvcHtmlString JavascriptTag(this System.Web.Mvc.HtmlHelper html, string fileName, string releaseFileName)
	{
		if (string.IsNullOrEmpty(fileName))
			throw new ArgumentNullException("fileName");
		string jsTag = string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>",
									 html.MeDebugReleaseString(fileName, releaseFileName));
		return MvcHtmlString.Create(jsTag);
    }
