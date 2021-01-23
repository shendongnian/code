     XElement doc2 = XElement.Load(Server.MapPath("TestXMLFile.xml"));
    List<XElement> _list = doc2.Elements().ToList(); 
    List<XElement> _list2 = new List<XElement>();
    foreach (XElement x in _list)
    {
        if (!x.Name.LocalName.StartsWith("Mandatory"))
        {
            _list2.Add(x);
        }
    }
    foreach (XElement y in _list2)
    {
        _list.Remove(y);
    }
