    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load(XmlString);
    
    string parse1_Content = xmlDocument.GetElementsByTagName("parse1")[0].InnerXml;
    Console.WriteLine("Contents of Parse 1: " + parse1_Content);
    
    if(xmlDocument.GetElementsByTagName("parse2") > 0)
    	Console.WriteLine("Parse 2 exists");
    	
    string parse3_Content = xmlDocument.GetElementsByTagName("parse1")[0].InnerText;
    Console.WriteLine(parse3_Content);
