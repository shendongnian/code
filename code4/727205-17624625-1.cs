    var employeeSalaryDictionary = new Dictionary<Employee, int>(new NameAgeEqualityComparer());
    employeeSalaryDictionary.Add(new Employee { Name = "Chuck", Age = 37 }, 1000);
    employeeSalaryDictionary.Add(new Employee { Name = "Norris", Age = 37 }, 2000);
    employeeSalaryDictionary.Add(new Employee { Name = "Rocks", Age = 44 }, 3000);
    
    Employee employeeToFind = new Employee { Name = "Chuck", Age = 37 };
    bool exists = employeeSalaryDictionary.ContainsKey(employeeToFind); // true!
