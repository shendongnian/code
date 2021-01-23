    var xml = @"<root>
                <notempty>text</notempty>
                <empty1><empty2><empty3/></empty2></empty1>
                </root>";
    var xDoc = XDocument.Parse(xml);
    RemoveAttributes(xDoc.Root);
    xDoc.Save(fileName2);
    void RemoveEmptyNodes(XElement xRoot)
    {
        foreach (var xElem in xRoot.Descendants().ToList())
        {
            RemoveEmptyNodes(xElem);
            if (String.IsNullOrWhiteSpace((string)xElem) && xElem.Parent!=null) 
                xElem.Remove();
        }
            
    }
