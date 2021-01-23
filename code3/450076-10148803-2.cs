    public static MvcHtmlString EditOrDelete(this HtmlHelper html)
    {
        using(html.BeginForm())
        {
            return MvcHtmlString.Create(" additional fields ");
        }
    }
