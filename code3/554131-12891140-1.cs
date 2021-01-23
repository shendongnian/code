    string filename = "XmlDoc.xml";
    System.IO.FileStream stream = new System.IO.FileStream (filename, System.IO.FileMode.Create);
    ds.WriteXml(stream); 
    XmlDocument xmldoc = new XmlDocument("XmlDoc.xml");
    XmlNode node1 = xmldoc.CreateNode("Books","Books");
    
    foreach(XmlNode nd in xmldoc.Nodes) {
      if(node.value =="Book")   
        node1.AppendChild(nd);
    }
    
    xmldoc.Nodes.Add(node1);
    xmldoc.SaveAs("newXmlDoc.Xml");
