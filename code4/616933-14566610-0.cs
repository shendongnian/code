    var xDoc = XDocument.Parse(xml); // XDocument.Load(filename);
    var x = new xyz()
        {  
            prop1 = xDoc.Root.Element("prop1").Value,
            prop2 = (int)xDoc.Root.Element("prop2"),
            prop3 = xDoc.Root.Element("data").Element("prop3").Value,
            prop4 = (int)xDoc.Root.Element("data").Element("prop4"),
        };
