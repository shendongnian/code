    string search_string = "GlobalZoneEU";
    
    var xDoc = XDocument.Load(path_of_hw);
    
    var users = xDoc.Root
                    .Elements("LICENSE_PATH")
    			    .Select(license => license.Element("FEATURE"))
    		        .Where(feature => (string)feature.Attribute("NAME") == search_string)
    			    .Select(feature => feature.Element("USER"));
    
    foreach (var xle in users)
    {
    	Console.WriteLine(xle.Attribute("NAME").Value);
    	Console.WriteLine(xle.Parent.Attribute("VERSION").Value);
    	Console.WriteLine(xle.Parent.Attribute("VENDOR").Value);
    	Console.WriteLine(xle.Parent.Attribute("START").Value);
    	Console.WriteLine(xle.Parent.Attribute("END").Value);
    	Console.WriteLine(xle.Attribute("USED_LICENSES").Value);
    	Console.WriteLine(xle.Parent.Attribute("TOTAL_LICENSES").Value);
    }
