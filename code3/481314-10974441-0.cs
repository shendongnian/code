    private void button1_Click_1(object sender, EventArgs e)
    {
        HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc;
        doc =  web.Load("http://slashdot.org");
 
        var node = CheckLine(doc.DocumentNode);
        if (node != null)
            MessageBox.Show(node.OuterHtml);
    }
    private HtmlAgilityPack.HtmlNode CheckLine(HtmlAgilityPack.HtmlNode node)
    {
        if (node.Line == 5 && node.LinePosition < 12 && ((node.LinePosition + node.OuterHtml.Length) > 12))
            return node;
        foreach (var n in node.ChildNodes)
        {
            var val = CheckLine(n);
            if (val != null)
                return val;
        }
        return null;
    }
