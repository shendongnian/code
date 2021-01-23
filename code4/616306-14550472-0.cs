    XDocument xDoc = new XDocument(new XElement("Mitarbeiterstatistik"));
    foreach (var mitarbeiter in list)
    {
        xDoc.Root.Add(
                new XElement("Mitarbeiter",
                    new XElement("Vorname" ,mitarbeiter.Vorname ),
                    new XElement("Nachname" ,mitarbeiter.Nachname ),
                    new XElement("Id" ,mitarbeiter.Id )));
                
    }
    xDoc.Save(@"d:\test.xml");
