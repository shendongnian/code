    Dictionary<string,double> dictionary = doc.Root.Descendants(ns + "class")
    				.ToDictionary(
    					element => element.Attribute("className").Value,
    					element => double.Parse(element.Attribute("p").Value));
    					
    foreach(var item in dictionary)
    {
    	Console.WriteLine(string.Format("{0}: {1}", item.Key, item.Value));
    }
