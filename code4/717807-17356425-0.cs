    private List<Customer> _custInfo;
    public List<Customer> CustInfo 
    { 
      get { return _custInfo ?? (_custInfo = new List<Customer>()); }
      set { _custInfo = value; }
    }
