    var elements = XElement.Load(filePath)
    .Elements()
    .ToList();
    var dict = new Dictionary<string, string>();    
    var _dict = elements.ToDictionary(key => key.Attribute("name").Value,
                            val => val.Attribute("value") != null ?
                            val.Attribute("value").Value : val.Value);
