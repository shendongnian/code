    var query =
        from n in _dc.Newsletter_Datas
        where n.Timestamp >= startDate
        select n;
    var news = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
        new XElement("USER",
            from n in query.AsEnumerable() // LINQ to objects
            select new XElement("ROW",
                new XElement("UTI", n.ID),
                new XElement("FIRSTNAME", n.FirstName),
                new XElement("FAMILYNAME", n.LastName),
                new XElement("GENDER", n.Gender),
                new XElement("BIRTHDATE", n.BirthDate != null ? n.BirthDate.Value.ToString("yyyy-MM-dd") : "2003-01-01"),
                new XElement("LANGUAGE", n.Language),
                new XElement("EMAIL", n.Email),
                new XElement("STREETNAME", n.StreetName),
                new XElement("HOUSENR", n.HouseNr),
                new XElement("BOXNR", n.BoxNr),
                new XElement("ZIPCODE", n.Zipcode),
                new XElement("CITY", n.City),
                new XElement("COUNTRY", n.Country),
                new XElement("TS", n.Timestamp.ToString("yyyy-MM-dd hh:mm:ss")),
                new XElement("MESSAGE_ID", "SCNEWS02"),
                new XElement("OPT_INS",
                    new XElement("OPT_IN",
                        new XElement("OPT_IN_CBP", "01000000000"),
                        new XElement("OPT_IN_INSERT_TS", n.Timestamp.ToString("yyyy-MM-dd hh:mm:ss")),
                        new XElement("OPT_IN_METHOD", "1"),
                        new XElement("OPT_IN_TYPE", n.OptIn),
                        new XElement("OPT_IN_CHANNEL", "2")
                    )
                )
            )
        )
    );
