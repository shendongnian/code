    public List<Person> QueryXmlUserLogin()
    { 
       var data = from item in XDocumentObj.Descendants("User_Data")
            select new Person
            {
                  User = item.Element("user").Value,
                  Password = item.Element("password").Value,
            };
       return data.ToList();
    }
