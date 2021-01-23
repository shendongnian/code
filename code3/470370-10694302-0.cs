    public void getListData()
    {
      WS_Lists.Lists myservice = new WS_Lists.Lists();
      myservice.Credentials = System.Net.CredentialCache.DefaultCredentials;
      myservice.Url = "http://merdev-moss:5050/testsara/_vti_bin/Lists.asmx";
      try
      {
        /* Assign values to pass the GetListItems method*/
        string listName = "{5C65CB1A-2E1B-488A-AC07-B115CD0FC647}";
        string viewName = "{75E689B4-5773-43CB-8324-58E42E1EB885}";
        string rowLimit = "100";
 
        // Instantiate an XmlDocument object
        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
        System.Xml.XmlElement query = xmlDoc.CreateElement("Query");
        System.Xml.XmlElement viewFields = xmlDoc.CreateElement("ViewFields");
        System.Xml.XmlElement queryOptions = xmlDoc.CreateElement("QueryOptions");
 
        /*Use CAML query*/
        query.InnerXml = "<Where><Gt><FieldRef Name=\"ID\" />" +
        "<Value Type=\"Counter\">0</Value></Gt></Where>";
        viewFields.InnerXml = "<FieldRef Name=\"Title\" />";
        queryOptions.InnerXml = "";
 
        System.Xml.XmlNode nodes = myservice.GetListItems(listName, viewName, query, viewFields, rowLimit, null, null);
 
        foreach (System.Xml.XmlNode node in nodes)
        {
            if (node.Name == "rs:data")
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    if (node.ChildNodes[i].Name == "z:row")
                    {
                        Response.Write(node.ChildNodes[i].Attributes["ows_Title"].Value + "</br>");
                    }
                }
            }
        }
    }
     catch (Exception ex)
     {
        Response.Write(ex.Message);
     }
    }
