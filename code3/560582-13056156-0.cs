    var xDoc = XDocument.Parse(xml); //XDocument.Load(filename)
    var dict = xDoc.Descendants("field")
                   .Where(e=>e.HasAttributes)
                   .ToDictionary(e => e.Attribute("name").Value, e => e.Value);
    Console.WriteLine(dict["currentsong"]);
