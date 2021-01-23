    XElement root = new XElement("RootNode");
    for (int j = 0; j < 10; j++)
    {
        XElement element = new XElement("SetGrid");
        element.SetElementValue("ID", j);
        root.Add(element);
    }
    
    var reader = root.CreateReader();//doc has 10 elements inside root element
    reader.MoveToContent(); // <-- missing line
    string result = reader.ReadOuterXml();//always empty string
