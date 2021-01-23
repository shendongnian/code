    XElement root = XElement.Load("UserClassDictionary.xml");
    Dictionary<string, string> values = new Dictionary<string, string>();
    foreach(XElement subNode in root.Elements)
    {
        values.Add(subNode.Name.LocalName, subNode.Element("ControlNumber").Value);
    }
