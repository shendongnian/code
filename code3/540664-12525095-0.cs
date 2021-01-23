    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
    doc.Load(@"c:\testapp\sample.xml");
    // Root element
    System.Xml.XmlElement root = doc.DocumentElement;
    System.Xml.XmlElement nameElement =(System.Xml.XmlElement)root.ChildNodes[0];
    string name = name.InnerText;
    System.Xml.XmlElement ageElemnent =(System.Xml.XmlElement)root.ChildNodes[1];
    string age = ageElemnent.InnerText;
    System.Xml.XmlElement sexElemnent =(System.Xml.XmlElement)root.ChildNodes[2];
    string sex= sexElemnent.InnerText;
       
