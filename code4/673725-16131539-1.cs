    var q = from c in this.Session.Query<Customer>()
            select new 
            { 
                Id = c.Id, 
                InfoCard = new Card
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        FullName = c.FirstName + " " + c.LastName
                    } 
            };
