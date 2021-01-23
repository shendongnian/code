    XElement root = new XElement("RootNode");
    for (int j = 0; j < 10; j++)
    {
        XElement element = new XElement("SetGrid");
        element.SetElementValue("ID", j);
        root.Add(element);
    }
    
    var reader = root.CreateReader();// root has 10 elements
    reader.MoveToContent(); // <-- missing line
    string result = reader.ReadOuterXml(); // now it returns non-empty string
