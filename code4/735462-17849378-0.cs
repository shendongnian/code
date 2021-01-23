    while (reader.Read())
    {
    	if (reader.NodeType == XmlNodeType.Element)
    	{
    		var testObject = new SomeInfo(); // moved inside the loop
    		string name = reader.Name;
    		switch (name)
    		{
    			case "Item1":
    				testObject.Imei = reader.Value;
    				test.Add(testObject); // add if it is item1
    				break;
    			case "Item2":
    				testObject.Imsi = reader.Value;
    				test.Add(testObject); // add if it is item2
    				break;
    		}
    		// if you add to list here, if it is not item1 or item2 you have null values
    	}
    }
