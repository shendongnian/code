    List<Customer> c = new List<Customer>();
    c.Add(new Customer() {CustomerName = "test", Email = "email" });
    c.Add(new Customer() { CustomerName = "test1", Email = "email1" });
    c.Add(new Customer() { CustomerName = "test2", Email = "email2" });
    c.Add(new Customer() { CustomerName = "test3", Email = "email3" });
    List<Employee> e = new List<Employee>();
    e.Add(new Employee() { EmployeeName = "test2", EmployeeID = "1" });
    e.Add(new Employee() { EmployeeName = "test1", EmployeeID = "2" });
    e.Add(new Employee() { EmployeeName = "test5", EmployeeID = "3" });
    e.Add(new Employee() { EmployeeName = "test4", EmployeeID = "4" });
    
    //remove from the Customers list the corresponding Employee 
    e.RemoveAll(x => c.Any(y => y.CustomerName == x.EmployeeName));
 
    foreach (var employee in e)
    {
        //TODO: 
    }
