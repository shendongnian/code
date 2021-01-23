       var result = from c in contacts
                     group c by new { c.firstname, c.lastname } into g
                     select new { LastName = g.Key.lastname, FirstName = g.Key.firstname, Contacts = g };
        var result1 = from c in companyList.SelectMany(company => company.Contacts)
                      group c by new { c.firstname, c.lastname } into g
                      select new { LastName = g.Key.lastname, FirstName = g.Key.firstname, Contacts = g };
