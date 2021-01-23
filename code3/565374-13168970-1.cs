    XDocument document = new XDocument(
        new XDeclaration("1.0", "utf-8", null),
        new XElement("data",
            new XElement("AnnualEnrollment", 
                from row in tableResult.Tables[0].AsEnumerable()
                select new XElement("row", 
                    from column in tableResult.Tables[0].Columns.Cast<DataColumn>()
                    select new XElement("column", row[column]))),
            new XElement("Pre-College"), // same for pre-college table
            new XElement("Summary") // and same for summary
            ));
