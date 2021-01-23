    using System.Xml;
    // --------------
    var doc = new XmlDocument();
              
    doc.Load(@"C:\source.xml");
            
    XmlNodeList nodeList;
    XmlNode root = doc.DocumentElement;
    nodeList=root.SelectNodes("category");
    Dictionary<string, string> fullName = new Dictionary<string, string>();
    foreach(XmlNode node in nodeList)
    {
      string nodeid = node.Attributes["category-id"].Value;
      string parent = node.Attributes["parent"].Value;
      string parentFullname = fullName[parent];
      string nodeFullname = (parentFullname != null) ? parentFullname + "." + nodeid : nodeid;
      fullName[nodeid] = nodeFullname;
    }
