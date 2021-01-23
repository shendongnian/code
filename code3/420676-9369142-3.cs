    public enum RenderModeEnum
    {
        Debug,
        Release,
        DebugAndRelease
    }
    public static MvcHtmlString CssTag(this System.Web.Mvc.HtmlHelper html, string fileName, RenderModeEnum tagRenderMode)
	{
		if (tagRenderMode == RenderModeEnum.DebugAndRelease)
			return html.CssTag(fileName);
    #if DEBUG
		if (tagRenderMode == RenderModeEnum.Debug)
			return html.CssTag(fileName);
    #else
		if (tagRenderMode == RenderModeEnum.Release)
			return html.CssTag(fileName);
    #endif
		return MvcHtmlString.Empty;
	}
	public static MvcHtmlString JavascriptTag(this System.Web.Mvc.HtmlHelper html, string fileName, RenderModeEnum tagRenderMode)
	{
		if (tagRenderMode == RenderModeEnum.DebugAndRelease)
			return html.JavascriptTag(fileName);
    #if DEBUG
		if (tagRenderMode == RenderModeEnum.Debug)
			return html.JavascriptTag(fileName);
    #else
		if (tagRenderMode == RenderModeEnum.Release)
			return html.JavascriptTag(fileName);
    #endif
		return MvcHtmlString.Empty;
	}
