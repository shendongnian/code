    var doc = XDocument.Load("Test.xml");
    
    var errors = doc.Descendants()
                    .Where(e => e.Attribute("ResultCode") != null &&
                                e.Attribute("ResultCode").Value == "ERROR" &&
                                !e.Elements().Any(c => c.Attribute("ResultCode") != null &&
                                                       c.Attribute("ResultCode").Value == "ERROR"));
