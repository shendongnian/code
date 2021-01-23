    Dictionary<string, object> greaderDic = new Dictionary<string,object>();
    foreach(var item in greader.Items/*or whatever you have to enumerate your greader*/)
    {
    greaderDic.Add(item.Name, GetValue(item.Name, item.Value));// hope you have something like Name or Value properties
    }
    
    object GetValue(string name, objetc value)
    {
    
    if (name.StartsWith("DISC_CODE"))
    return value == null? "NULL" : Convert.ToChar(value)
    
    if (name.StartsWith("DISC_PCT"))
    return value == null? "NULL" : Convert.ToDouble(value);
    
    throw new Exception("Mapping not found for " + item.Name);
    
    }
