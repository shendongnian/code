    Dictionary<int, string> elements = xml.Elements(ns + "root")
            .Select(sp => new { 
                                  CustRef = (string)(sp.Attribute("CustRef")), 
                                  vendor = (string)(sp.Attribute("Vendor")) 
                              })
            .ToDictionary(sp => sp.CustRef, sp => sp.Vendor);
