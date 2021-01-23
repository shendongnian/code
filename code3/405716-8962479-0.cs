    public Customers()
    {
        customers = new List<Customers>();
        AddCustomer(new Customers() // <- Here
        { 
        Name = "A", Telephone="1" 
        });
    }
