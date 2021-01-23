    XElement root = XElement.Parse(xml);
    var foo = new Foo()
    {
        SaveCode = (string)root.Element("SaveCode"),
        IsMainProject = (bool)root.Element("IsMainProject"),
        DesignerItems = root.Element("DesignerItems")
                            .Elements("DesignerItem")
                            .Select(di => new DesignerItem()
                            {
                                Quiddity = (string)di.Element("Quiddity"),
                                Name = (string)di.Element("Name"),
                                LoopBodyInDesignerCanvas = (string)di.Element("LoopBodyInDesignerCanvas")
                            }).ToList()
    };
