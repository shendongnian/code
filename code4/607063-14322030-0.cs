    StringBuilder sb = new System.Text.StringBuilder();
    using (var stringWriter = new System.IO.StringWriter(sb))
    {
        using (var htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter))
        {
            YourPlaceHolder.RenderControl(htmlTextWriter);
        }
    }
    return sb.ToString();
