    HtmlWindow window = webBrowser1.Document.Window;
    string str = window.Document.Body.OuterHtml;
    HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
    HtmlDoc.LoadHtml(str);
    HtmlAgilityPack.HtmlNodeCollection Nodes = HtmlDoc.DocumentNode.SelectNodes("//a");
    foreach (HtmlAgilityPack.HtmlNode Node in Nodes)
    {
        textBox1.Text += Node.OuterHtml + "\r\n";
    }
