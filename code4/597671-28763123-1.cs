    var xmlString = "...";  // <--- your xml here
    var xml = new XmlDocument();
    xml.LoadXml(xmlString);
    var xnList = xml.SelectNodes("/Engagements/User");
    var test = "";
    if (xnList != null) 
    foreach (XmlNode xn in xnList)
    {
        if (xn.Attributes != null)
        {
            if (xn.Attributes[0].Value == "kkkk")
            {
                if (xn.FirstChild.Attributes != null)
                {
                    var xmlElement = xn.FirstChild.Attributes[0].Value;
                    if (xmlElement != null)
                    {
                        test = xmlElement;
                    }
                }
            }
        }
        
    }
    Console.WriteLine(test);
    Console.Read();
            
