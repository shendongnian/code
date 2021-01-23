    public void LoadValueXML()
    {
        XDocument myxml = XDocument.Load("config.xml");
        Items = myxml.Root.Elements("Item").OrderBy(x => (int)x.Attribute("ID"));
        ItemsLength = Items.Count();
    }
