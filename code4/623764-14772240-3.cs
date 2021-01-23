    Component_1 c = Deserialize<Component_1>(project.ChildNodes[0].OuterXml);
    for (int i = 0; i < c.objectArray.Length; i++)
    {
        var type = _typeCache[(((System.Xml.XmlNode[])(c.objectArray[i]))[0]).Value];
        var item = Convert.ChangeType((((System.Xml.XmlNode[])(c.objectArray[i]))[1]).Value, type);
        c.objectArray[i] = item;
    }
    Console.WriteLine(c.objectArray[0].GetType()); // -> System.String
