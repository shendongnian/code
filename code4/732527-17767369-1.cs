    public List<Customers> AllCustomers() {get; set;}
    public List<Customers> WaitingCustomers()
    {
       get
       {
          return AllCustomers.Where(x => x.Sate == CustomerState.IsWaiting);
       }
    }
    public List<Customers> OrderedCustomers()
    {
       get
       {
          return AllCustomers.Where(x => x.Sate == CustomerState.HasOrdered);
       }
    }
    //and so on...
