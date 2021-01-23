    // can also use XDocument.Load(...) to load from a file or stream.
    var document = System.Xml.Linq.XDocument.Parse(xml);
    var settingsList = (from element in document.Root.Elements("setting")
                        select new Setting
                        {
                            Name = element.Attribute("name").Value,
                            Color = element.Attribute("color").Value,
                            Align = element.Attribute("align").Value
                        }).ToList();
