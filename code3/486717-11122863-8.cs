    public ActionResult GetEmployees([DataSourceRequest]DataSourceRequest request)
    {
        List<Employee> list = new List<Employee>();
        Employee employee = new Employee() { EmployeeId = 1, Name = "John Smith", Department = "Sales" };
        list.Add(employee);
        employee = new Employee() { EmployeeId = 2, Name = "Ted Teller", Department = "Finance" };
        list.Add(employee);
        return Json(list.ToDataSourceResult(request));
    }
