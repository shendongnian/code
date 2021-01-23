    XDocument myDocument = XDocument.Load("path to my file");
    foreach (XElement node in myDocument.Root.Descendants("placeholder"))
    {
        if (node.Value.Contains("same"))
        {
            XElement newNode = new XElement("placeholder");
            newNode.Add(new XAttribute("header", node.Attribute("header").Value); // if you want to copy the current value
            newNode.Add(new XAttribute("width", "some new value"));
            node.ReplaceWith(newNode);
        }
    }
