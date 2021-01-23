    public List<Customer> MyMethod() 
    {
    
        List<Customer> newCustomer = new List<Customer>
        { 
           new Customer
           {
           Name="A",                   //Name and Telephone are properties.
           Telephone="02-333444"
           },
    
           new Customer
           {
           Name="B",
           Telephone="03-444555"
           },
           new Customer
           {      
           Name="D",
           Telephone="03-444555"
           },
    
        };
    
        return newCustomer;
    }
