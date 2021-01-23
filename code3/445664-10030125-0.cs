    // Variable declaration
    volatile List<ZGpCustomer> _customers = new List<ZGpCustomer>();
    
    // Writer
    lock (_customers)
    {
      var copy = new List<ZGpCustomer>(_customers);
      // Modify the copy here.
      _customers = copy;
    }
    
    // Reader
    public List<ZGpCustomer> GetCustomers()
    {
        return new List<ZGpCustomer>(_customers);
    }
