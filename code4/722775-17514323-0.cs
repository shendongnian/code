    XmlReader reader = XmlReader.Create(@"dataIn.xml");
    XmlDocument doc = new XmlDocument();
    doc.Load(reader);
    XmlNodeList elem = doc.GetElementsByTagName("important");
    List<string> originalOrder = new List<string>();
    
    foreach (XmlNode tag in elem)
      {
        originalOrder.Add(tag.InnerXml);
      }
    
    int numberOfNodes = elem.Count;
    
    for (int i = 0; i < numberOfNodes; i++) {
        elem[i].InnerXml = order[order.Count - 1 - i];
      }
    doc.Save(@"dataOut.xml");
