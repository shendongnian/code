    var employees = LoadEmployeesFromUnderlyingDataStore();
    var criterion = new FilterCriterion();
    switch(searchMeth) {
        case "Name": filter.EmployeeName = "the name to filter by"; break;
        case "EmployeeNumber": filter.EmployeeNumber = "the number to filter by"; break;
        case "Department": filter.Department = "the department to filter by"; break;
    }
    var filter = PredicateBuilder.True<Employee>(); // assuming you have an employee class.
    if (criterion.HasEmployeeName) 
        filter.And(e => e.Name.ContainsLike(criterion.EmployeeName));
    if (criterion.HasEmployeeNumber)
        filter.And(e => e.EmployeeNumber.ContainsLike(criterion.EmployeeNumber));
    if (criterion.HasDepartment)
        filter.And(e => e.Department.ContainsLike(criterion.Department));
    var filteredEmployees = employees.Where(filter);
    // Supply your ObjectListView the way you're used to and this shall function.
