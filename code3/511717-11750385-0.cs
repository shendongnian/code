    var vcontact = from c in context.Contacts
                   orderby c.LastName
                   where c.Addresses.Any(a => a.City == "Toronto")
                   select new Contact
                   {
                       LastName = c.LastName;
                       // map all remaining properties of Contact
                       Addresses = c.Addresses.Where(a => a.City == "Totonto")
                   }; 
