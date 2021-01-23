    var employees = ListOfEmployee
        .GroupBy(e => e.Category)
        .Select(g =>
            new EmployeeModel()
            {
                EmployeeCategory = g.Key,
                EmployeeList = g.Select(e =>
                    new Employee()
                    {
                        EmployeeName = e.Name
                    }).ToList()
            });
    return new ObservableCollection<EmployeeModel>(employees);
