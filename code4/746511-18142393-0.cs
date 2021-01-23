    // Your data
    var users = new List<User> {
        new User { Name = "John", Age = 42 },
        new User { Name = "Jane", Age = 39 }
    };
	
    // Project the data into XElements
    var userElements = 
        from u in users		
        select 
            new XElement("user", u.Name, 
                new XAttribute("age", u.Age));
		
    // Build the XML document, add namespaces and add the projected elements
    var doc = new XDocument(
        new XElement("RDF",
            new XAttribute(XNamespace.Xmlns + "cim", 
                XNamespace.Get("http://iec.ch/TC57/2009/CIM-schema-cim14#")),
            new XAttribute(XNamespace.Xmlns + "rdf", 
                XNamespace.Get("http://www.w3.org/1999/02/22-rdf-syntax-ns#")),
            userElements
        )
    );		
    doc.Save(@"c:\xml-test.xml");
