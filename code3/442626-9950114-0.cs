    string x = @"<?xml version='1.0'?> 
     <EXAMPLE>  
        <a href='/abc/def'>Hello</a> 
     </EXAMPLE>";
    
     System.Xml.XmlDocument doc = new XmlDocument();
     doc.LoadXml(x);
     XmlNode n = doc.SelectSingleNode("//a[@href='/abc/def']");
     XmlNode p = n.ParentNode;
     p.RemoveChild(n);
     System.Xml.XmlNode newNode = doc.CreateNode("element", "a", "");
     newNode.InnerXml = "Hello";
     p.AppendChild(newNode);
