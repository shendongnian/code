    XmlReader xmlReader = XmlReader.Create("http://webservices.nextbus.com/service/publicXMLFeed?   command=routeConfig&a=sf-muni&r=N");
    List<string> aTitle= new List<string>();
    
    // Add as many as attributes you have in your "stop" element
    
    while (xmlReader.Read())
    {
     //keep reading until we see your element
     if (xmlReader.Name.Equals("stop") && (xmlReader.NodeType == XmlNodeType.Element))
     {
       string title = xmlReader.GetAttribute("title");
       aTitle.Add(title);
       // Add code for all other attribute you would want to store in list.
      }
    }
