    XElement root = XElement.Load("UserClassDictionary.xml");
    Dictionary<string, List<string>> values = new Dictionary<string, List<string>>();
    foreach(XElement subNode in root.Elements())
    {
        values.Add(subNode.Name.LocalName, subNode.Elements("ControlNumber")
            .Select(x => x.Value).ToList());
    }
