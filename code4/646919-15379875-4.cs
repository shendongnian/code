    XElement _customers = new XElement("Students",
                           from c in objCust
                           orderby c.CustID //descending 
                            select new XElement("Student",
                                new XElement("name", c.StudentID),
                                new XElement("ID", c.FirstName),
                                new XElement("phone", c.LastName),
                                new XElement("Fees", (from x in x.Fees
                                                      orderby x.FeeID//descending 
                                select new XElement("FeeID",x.FeesId)) 
                            ))
    
                      );
