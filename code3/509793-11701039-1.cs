    List<Customer> customers = null;
    try
    {
         customers = (List<Customers>)DataSource.GetCustomers();
    }
    catch
    {
        customers = DataSource.GetCustomers().ToList();
    }
