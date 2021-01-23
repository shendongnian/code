    public IEnumerable<Employee> GetEmployeesInAccounting()
    {
        using(var myContext = new MyDbContext())
        {
            return myContext.Employees.Where(emp => emp.Department == 'Accounting');
        }
    }
    
    // Code that fails, Assuming Manager is a lazy loaded entity, this results in an exception but it compiles no problem
    var acctEmps = GetEmployeesInAccounting();
    var something = acctEmps.First().Department.Manager.Department;
