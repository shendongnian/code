    College coll = ...
    XDocument doc = new XDocument(
      new XElement("College",
        new XElement("Name", coll.Name),
        new XElement("Address", coll.Address),
        new XElement("Persons", coll.Persons.Select(p =>
          new XElement("Person",
            new XElement("Gender", p.Gender),
            new XElement("City", p.City)
          )
        )
      )
    );
    
