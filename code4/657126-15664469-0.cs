    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(htmlFromDB);
    var query = doc.DocumentNode.Decendants("cm:control");
    foreach(var node in query)
    {
       string userControlHTML = GetHTML(new MyUserControl());
       var newNode = HtmlNode.CreateNode(userControlHTML);
       node.ParentNode.ReplaceChild(newNode, node);
    }
    //render doc.DocumentNode.OuterHtml in literal control on your page
    ...
    static public string GetHTML(Control myControl)
    {
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter myWriter = new HtmlTextWriter(sw);
        myControl.RenderControl(myWriter);
        return sw.ToString();
    }
