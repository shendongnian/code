    return (from i in this.Elements("Connection")
            where i.Element("ConnectionName").Value == stubConnectionName
            select new StubConnection(stubConnectionName,
                                      i.Element("InterfaceName").Value,
                                      i.Element("RequestFolder").Value,
                                      i.Element("ResponseFolder").Value)).Single();
