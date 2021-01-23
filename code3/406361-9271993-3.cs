    public static MvcHtmlString DrawControl(this HtmlHelper htmlHelper, string id, ...)
    {
        var model = new FieldControl() { ID = id, ... };
        return htmlHelper.Action("DrawControl", model);
    }
    public static MvcHtmlString DrawSimpleControl(this HtmlHelper htmlHelper, string id, ...)
    {
        return DrawSimpleControl(htmlHelper, id, ...);
    }
    public static MvcHtmlString DrawSimpleControl(this HtmlHelper htmlHelper, string id, ...)
    {
        // Set some defaults to simplify the API
        return DrawControl(htmlHelper, id, ...);
    }
    public static MvcHtmlString DrawComplexControl<T>(this HtmlHelper htmlHelper, string id, ...) where T : AbstractComplex, new()
    {
        // Build the required controls based on `T`
        return DrawControl(htmlHelper, id, ...);
    }
