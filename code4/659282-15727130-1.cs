    foreach (var item in result)
    {
        string format = item.Attribute("format").Value.ToString();
        string name = item.Element("name").Value.ToString();
        string combineDate = item.Element("combineDate").Value.ToString();
        string combineTime = item.Element("combineTime").Value.ToString();
    }
            
