    var prospects = (from prospect in xdoc.Descendants("PROSPECT")
                        select new Prospect {
                            ProspectID =
     (string)prospect.Element("PROSPECTINFO").Element("PROSPECT_ID"),
                            Name =
     (string)prospect.Element("PERSONALINFO").Element("FIRSTNAME")+ " " + prospect.Element("PERSONALINFO").Element("SURNAME"),
                            address =
     (string)prospect.Element("CONTACTINFO").Element("ADDRESSLINE1").Element("ANSWER"),
                            zipCode =
     (string)prospect.Element("CONTACTINFO").Element("POSTALCODE").Element("ANSWER").Value,
                            City =
     prospect.Element("CONTACTINFO").Element("CITY") != null ?
         (string)prospect.Element("CONTACTINFO").Element("CITY").Element("ANSWER") :
         string.Empty,
       }).ToList();
