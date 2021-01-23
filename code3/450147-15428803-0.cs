    public void ReadXML()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("<name file>.xml");
        xmlEntities = new List<XmlEntity>();
    
        foreach(XmlNode item in xmlDoc.ChildNodes)
        {
            GetChildren(item);
        }
    }
    
    private void GetChildren(XmlNode node)
    {
        if (node.LocalName == "Строка")
        {
           //<you get the element here and work with it>
        }
        else
        {
           foreach (XmlNode item in node.ChildNodes)
           {
                 GetChildren(item);
           }
        }
    }
