    XDocument document = new XDocument(
        new XDeclaration("1.0", "utf-8", null),
        new XElement("data",
            new XElement("AnnualEnrollment", tableResult.Tables[0].ToXml()),
            new XElement("Pre-College", tableResult.Tables[1].ToXml()),
            new XElement("Summary", tableResult.Tables[2].ToXml()) 
            ));
