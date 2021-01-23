         XElement userListXml = _client.GetSystemWideListXml(
                new UsersFilterData { 
                       BaseColumns = ListBaseColumns.Default, 
                       IsPredefined = false 
                 });
      
         // LINQ to query by description
        var user = (from el in userListXml.Elements()
                    where (string) el.Attribute("Description") == "USERDESCRIPTON" 
                    select el).FirstOrDefault();
        string usrTcmURI = user.Attribute("ID").Value;
