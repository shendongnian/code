    var customer = new Customer();
    customer.name = txtCustomerName.Text;
    
    // only starting with one customer type selected in a check box list
    //add Include there
    CustomerType customerType = context.CustomerTypes.Include("Customers").FirstOrDefault(i => i.Id == 1);
    
    using (var context = new MyEntities())
    {
        // IncidentTypes throws Object reference not set to an instance of an object
        //customer.CustomerTypes.add(customerType);
    
        //context.Customers.Add(customer);
        customerType.Customers.Add(customer);
        context.SaveChanges();  
    }
