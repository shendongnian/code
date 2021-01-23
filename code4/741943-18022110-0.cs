    public ICollection<Employee> Employees { get; set; }
    public List<string> AllEmployeesList 
    { 
        get
        {
            return this.Employees.Select<Employee, string>(x => x.FirstName).ToList();
        }
        private set; 
    }
