    XmlDocument Doc = new XmlDocument();
    Doc.Load(HttpContext.Current.Server.MapPath("Your xml file path"));
   
    XmlNodeList nodeList = MenuListNode.SelectNodes("//College");
    string value= "";
    
    if(nodeList.Attributes("id").Value.Equals("1"))
    {
        value = nodeList.Attributes("id").Value.ToString() + "|";
        foreach (XmlNode MenuNode in MenuListNode.ChildNodes)
        {
            value = value + MenuNode.InnerText.ToString() + "|";
        }
    }
