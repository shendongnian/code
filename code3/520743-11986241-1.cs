    foreach(XmlNode node in nodeList)
    {
      if(node.Name == "code")
      {
        string code = node.InnerText;
      }
      else
      if(node.Name == "message")
      {
        string msg = node.InnerText;
      }
    }
