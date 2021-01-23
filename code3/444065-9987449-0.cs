            XNamespace ns = XNamespace.Get(""); //use the xmnls namespace here
            XElement element = XElement.Load(""); // xml file path
            var result = element.Descendants(ns + "videostatus")
                         .Select(o =>o.Value).ToList();
              
           foreach(var values in value)
           {
                
           }           
