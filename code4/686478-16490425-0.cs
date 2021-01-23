    var myItems = new Dictionary<string, Dictionary<string, string>>();
    
    myItems.Add("Item 1", null);
    myItems.Add("Item 2", null);
    
    var subDictionary1 = new Dictionary<string, string>();
    subDictionary1.Add("subKey1", "subValue1");
    subDictionary1.Add("subKey2", "subValue2");
    myItems.Add("Item 3", subDictionary1);
    
    var subDictionary2 = new Dictionary<string, string>();
    subDictionary2.Add("subKey1", "subValue1");
    myItems.Add("Item 4", subDictionary2);
    
    var subDictionary3 = new Dictionary<string, string>();
    subDictionary3.Add("subKey1", "subValue1");
    subDictionary3.Add("subKey2", "subValue2");
    subDictionary3.Add("subKey3", "subValue3");
    myItems.Add("Item 5", subDictionary3);
