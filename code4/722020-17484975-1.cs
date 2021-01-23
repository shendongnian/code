    protected void Page_PreRender(Object sender, EventArgs e)
    {
        string thisHtml = RenderControl(this.Form);
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(thisHtml);
        var nodeColl = doc.DocumentNode.SelectNodes("//*[contains(@class,'fooClass')]");
        Console.WriteLine("Count: " + nodeColl.Count);
        // here a linq approach with the same result:
        var nodes = doc.DocumentNode.Descendants()
            .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value=="fooClass");
        Console.WriteLine("Count: " + nodes.Count());
    }
    private string RenderControl(Control control)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter writer = new HtmlTextWriter(sw);
        control.RenderControl(writer);
        return sb.ToString();
    }
