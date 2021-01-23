    var myFilters = new List<Expression<Func<Customer, bool>>>();
    myFilters.Add(c => c.Name.StartsWith("B"));
    myFilters.Add(c => c.Orders.Count() == 3);
    if (stranded)
    {
      myFilters.Add(c => c.Friends.Any(f => f.Cars.Any())); //friend has car
    }
    Expression<Func<Customer, bool>> filter = myFilters.AndTheseFiltersTogether();
    IEnumerable<Customer> thoseCustomers = Data.Get(filter);
