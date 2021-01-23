    private XDocument FilterRoles(XDocument xmlDoc)
    {
        XElement element = xmlDoc.Element("SiteMenuItems");
        XElement root = new XElement("SiteMenuItems",
                        (
                            from sm
                            in element.Descendants("SiteMenuItem")
                            where UserHelper.IsUserAuthorized(sm.Attribute("roles"))
                            select new XElement(sm))
                        );
    
        XDocument menuXml = new XDocument();
        menuXml.Add(root);
        return menuXml;
    }
