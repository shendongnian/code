    private List<Employee> employees = new List<Employee>();
    public IList<Employee> Employees { get { return this.employees; } }
    // ...
    this.employees.Add(new Hourly("1000", "Harry","Potter", "L.", "Privet Drive", "201-9090", "40.00", "12.00"));
    // .. Add all
