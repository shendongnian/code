	public static MvcHtmlString CssTag(this System.Web.Mvc.HtmlHelper html, string fileName)
	{
		return html.CssTag(fileName, string.Empty);
	}
	public static MvcHtmlString CssTag(this System.Web.Mvc.HtmlHelper html, string fileName, string releaseFileName)
	{
		if (string.IsNullOrEmpty(fileName))
			throw new ArgumentNullException("fileName");
		string cssTag = string.Format(
			"<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\" />",
			html.MeDebugReleaseString(fileName, releaseFileName));
		return MvcHtmlString.Create(cssTag);
	}
