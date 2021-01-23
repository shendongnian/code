    static void DumpContents(CustomerGrp customerGrp)
    {
        Console.WriteLine("------- Customer Content -------");
        Console.WriteLine("         Id: {0}", customerGrp.GroupId);
        DumpContents(customerGrp.Executive);
        foreach (Customer cust in customerGrp.Customers)
        {
            DumpContents(cust); // <- Exception Error line here
        }
        Console.WriteLine("--------------------------------");
    }
    
    
    static void DumpContents(Employee employee)
    {
        Console.WriteLine("------- Employee Content -------");
        Console.WriteLine("         Id: {0}", employee.Id);
        ...
    }
        
        
    static void DumpContents(Customer customer)
    {
        Console.WriteLine("------- CustomerContent -------");
        Console.WriteLine("         Id: {0}", customer.Id);
        ...
    }
