    XmlDocument xml = new XmlDocument();
    xml.LoadXml(myXmlString); // suppose that myXmlString contains "<Body>...</Body>"
    
    XmlNodeList xnList = xml.SelectNodes("/Envelope/Body");
    foreach (XmlNode xn in xnList)
    {
      string binary1 = xn["Binary1"].InnerText;
      string binary2 = xn["Binary2"].InnerText;
      Console.WriteLine("Binary: {0} {1}", binary1 , binary2);
    }
