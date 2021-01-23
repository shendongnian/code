    XmlDocument xDoc = new XmlDocument();
    xDoc.Load("Server.MapPath("~/XMLFile.xml")");
    XmlNodeList nodeList;
    nodeList = xDoc.DocumentElement.SelectNodes("Employee");
    foreach (XmlNode emp in nodeList)
    {
        foreach (XmlNode child in emp.ChildNodes)
        {
            Response.Write(child.LocalName);
            Response.Write(":");
            Response.Write(child.InnerText);
            Response.Write("\n");
        }
    }
