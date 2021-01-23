    HtmlDocument doc = new HtmlDocument();
    doc.Load(myFileHtm);
    
    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a"))
    {
        // replace the HREF element in the DOM at the exact same place
        // by a deep cloned one, with a different name
        HtmlNode newNode = node.ParentNode.ReplaceChild(node.CloneNode("Hyperlink", true), node);
    
        // modify some attributes
        newNode.SetAttributeValue("NavigateUri", newNode.GetAttributeValue("href", null));
        newNode.Attributes.Remove("href");
    }
    doc.Save(Console.Out);
