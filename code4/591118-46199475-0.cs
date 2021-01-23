    public static IHtmlString RenderSectionCustom(this HtmlHelper html)
    {
        WebViewPage page = html.ViewDataContainer as WebViewPage;
        var section = page.RenderSection("CustomTop", false);
        return section == null ? MvcHtmlString.Empty : MvcHtmlString.Create(section.ToHtmlString());
    }
    public static IHtmlString DefineSectionCustom(this HtmlHelper html)
    {
        WebViewPage page = html.ViewDataContainer as WebViewPage;
        page.DefineSection("CustomTop", () =>
        {
            page.Write(MvcHtmlString.Create(" hello world (custom top section from HTML HELPER)!"));
        });
        return MvcHtmlString.Empty;
    }
