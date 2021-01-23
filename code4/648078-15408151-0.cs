    private List<Employee> CloneEmployees(List<Employee> original)
    {
        var newList = new List<Employee>();
        foreach (var employee in original)
        {
            newList.Add(new Employee 
                { 
                    FirstName = employee.FirstName, 
                    LastName = employee.LastName, 
                    isActive = employee.isActive 
                });
        }
        return newList;
    }
