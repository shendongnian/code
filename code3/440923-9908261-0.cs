    public List<Tuple<string, string>> QueryXmlUserLogin()
    { 
        var data = from item in XDocumentObj.Descendants("User_Data")
                   select Tuple.Create(item.Element("user").Value, item.Element("password").Value);
        return data.ToList();
    }
