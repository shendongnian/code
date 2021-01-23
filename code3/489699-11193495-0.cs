    HtmlDocument doc = new HtmlDocument;
    doc.Load("filepath");
    
    HtmlNode node = doc.DocumentNode.SelectSingleNode("//span"); //Here, you can also do something like (".//span[@id='targetID']"); to select specific spans, etc...
    string value = node.InnerText; //this string will contain the value of span, i.e. <span>***value***</span>
