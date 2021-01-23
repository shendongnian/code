    XmlTextReader reader = new XmlTextReader(@"D:\myfile.xml");
    List<string> result = new List<string>();
    
    while (reader.Read())
    {    
        if (reader.Name == "brand")
        {
            XmlReader inner = reader.ReadSubtree();
            List<string> names = new List<string>();
    
            while (inner.Read())
            {
                if (reader.Name == "driver")
                    names.Add(reader.GetAttribute("name"));
            }
    
            if (names.Any())
                result.Add(String.Join(" - ", names));
        }
    }
