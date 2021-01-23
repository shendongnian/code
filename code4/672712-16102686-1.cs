     var result = (from s in Customers
                         select new {
                             s.Surname, 
                             s.FirstName,
                             Convert.ToString(s.CustomerID),
                             s.Gender,
                             s.Notes,
                             s.DateUpdated.ToString("dd/MM/yyyy HH:mm")
                         }).ToArray(); //here
