    var list = new List<Dictionary<string, string>>();
    foreach (XElement elem in doc.Descendants("Person"))
    {
        var dataDictionary = new Dictionary<string,string>();
        var row = elem.Descendants();
        foreach (XElement element in row)
        {
           string keyName = element.Name.LocalName;
           dataDictionary.Add(keyName, element.Value);
        }
        list.Add(dataDictionary);
    }
    var enumDict = list.AsEnumerable();
