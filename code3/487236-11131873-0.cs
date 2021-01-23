    Dictionary<Int32,Dictionary<String, String>> countryDict= new Dictionary<Int32,Dictionary<String, String>>()
    foreach(var item in myGenericList){
        Dictionary<Int32,Dictionary<String, String> stateDict = 
        countryDict[item.CountryID] ?? new Dictionary<Int32,Dictionary<String, String>>();
        stateDict.Add(item.StateID.ToString(),item.StateName) 
    }
