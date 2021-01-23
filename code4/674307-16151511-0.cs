    [HttpGet]
    public HttpResponseMessage GetPerson(int personId)
    {
        var doc = XDocument.Load(path);
        var result = doc
            .Element("Persons")
            .Elements("Person")
            .Single(x => (int)x.Element("PersonID") == personId);
        var xml = new XElement("TheRootNode", result).ToString();
        return new HttpResponseMessage 
        { 
            Content = new StringContent(xml, Encoding.UTF8, "application/xml") 
        };
    }
