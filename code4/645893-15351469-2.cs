    public HomeController(IEmployeeRepository empRepository)
    {
        repoEmployee = empRepository;
        repoEmployee.Initialise(/* use your method to pass the Tenant ID here*/);
    }
