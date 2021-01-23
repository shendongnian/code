    var customers = new List<Customer>()
    {
        new Customer()
        {
            FirstName = "Jo",
            LastName = "Bloggs",
            Email = "jo@bloggs.com",
            DOB = "10/12/1960"
        }
    };
    foreach (var customer in customers)
    {
        var emailMessage = String.Format("Hi {0}. Its {1}, nice to see you were born on the {2}!", customer.FirstName, DateTime.Today, customer.DOB);
        customEmails.Add(customer.Email,emailMessage);
    }
