    XDocument doc = XDocument.Load("config.xml");
    foreach (var element in doc.Descendants("Preset"))
    {
        var preset = new Preset { name = element.Attribute("Name").Value };
        presetList.Add(preset);
        Console.WriteLine("Preset list ID " + preset);
        foreach (var id in element.Descendants("ID"))
        {
            Console.WriteLine(id.Value);
        }
    }
