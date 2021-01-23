    var orders =  from customer in Customers.AsEnumerable()
                  join contact in Contacts.AsEnumerable()
                  on customer.Field<int>("CustomerID") equals contact.Field<int>("CustomerID") into outer
                      from contact in outer.DefaultIfEmpty()
                      orderby contact["ContactName"]   
                      select new
                      {
                            ContactID = contact.Field<int>("ContactID"),
                            Name =  contact.Field<String>("ContactName"),
                            City =  contact.Field<String>("City")
                      };
