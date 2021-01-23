    public static string GetRenderedHtml(this Control control)
    {
        StringBuilder sbHtml = new StringBuilder();
        using (StringWriter stringWriter = new StringWriter(sbHtml))
        using (HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter))
        {
            control.RenderControl(textWriter);
        }
        return sbHtml.ToString();
    }
