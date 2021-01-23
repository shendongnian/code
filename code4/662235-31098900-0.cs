    public Interface ICustomerRepository 
    {
    
    public IEnumerable< Customer> GetAllCustomer()
    
    public IEnumerable< Debtor> GetAllDebtors()
    
    public IEnumerable< CustomerSummary> GetCustomerSummaryByName(string name)
    
    public IEnumerable< CustomerSummary> GetCustomerSummaryById(string id)
    }
