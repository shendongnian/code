     public double ParseAge(string age){
          double parsedAge = -1;
          Double.TryParse(age, out parsedAge);
          return parsedAge;
     }
     public List<Customers> GetCustomer(string anything)
     {
        double double1 = Age;
        List<Customers> customers = customermembers.Where(n =>
                                           string.Equals(n.CustomerID, anything, StringComparison.CurrentCultureIgnoreCase)
                                           || string.Equals(n.FirstName, anything, StringComparison.CurrentCultureIgnoreCase)
                                           || string.Equals(n.LastName, anything, StringComparison.CurrentCultureIgnoreCase)
                                           || n.Age == ParseAge(anything) //this like
                                       ).ToList();
        return customers;
     }
