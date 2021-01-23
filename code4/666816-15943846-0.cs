    public static IHtmlString BeginScript(this HtmlHelper htmlHelper)
    {
       return new HtmlString("<script type=\"text/javascript\">");
    }
    
    public static IHtmlString EndScript(this HtmlHelper htmlHelper)
    {
        return new HtmlString("</script>");
    }
