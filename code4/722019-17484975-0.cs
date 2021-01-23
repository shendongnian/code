    protected void Page_PreRender(Object sender, EventArgs e)
    {
        string thisHtml = RenderControl(this.Form);
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(thisHtml);
        var nodeColl = doc.DocumentNode.SelectNodes("//*[contains(@class,'fooClass')]");
        Console.WriteLine("Count: " + nodeColl.Count);
    }
    private string RenderControl(Control control)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter writer = new HtmlTextWriter(sw);
        control.RenderControl(writer);
        return sb.ToString();
    }
