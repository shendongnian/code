    // Variable declaration
    object lockobj = new object();
    volatile List<ZGpCustomer> _customers = new List<ZGpCustomer>();
    
    // Writer
    lock (lockobj)
    {
      // Create a temporary copy.
      var copy = new List<ZGpCustomer>(_customers);
      // Modify the copy here.
      copy.Add(whatever);
      copy.Remove(whatever);
      // Now swap out the references.
      _customers = copy;
    }
    
    // Reader
    public List<ZGpCustomer> GetCustomers()
    {
        return new List<ZGpCustomer>(_customers);
    }
