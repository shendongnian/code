    var query = customers.Concat(new Customer[]
        { 
            new Customer
                {
                    ID = customers.Max(c => c.ID) + 1,
                    FirstName = "Vince",
                    LastName = "Vaughn"
                }
        }).OrderBy(c => c.FirstName);
