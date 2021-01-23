    var xdoc = XDocument.Load(fileManager.ConfigFile);
    var serverConfig = xdoc.Root;
    string version = (string)serverConfig.Attribute("version");
    DateTime date = (DateTime)serverConfig.Attribute("createDate");
    string type = (string)serverConfig.Attribute("type");
    
    var items = from item in serverConfig.Element("items").Elements()
                select new {
                    Name = (string)item.Attribute("name"),
                    Type = (string)item.Attribute("type"),
                    Source = (string)item.Attribute("source"),
                    Destination = (string)item.Attribute("destination")
                };
