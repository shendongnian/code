    var query = Employeecollection.GroupBy(x => new
    {
        x.EmpName,
        x.EmpDept
    };
    foreach (var group in query)
    {
        string languages = string.Join(", ", 
            group.Select(employee => employee.KnownLanguages)
            .Distinct());
        Console.WriteLine(group.Key.EmpName + "   " + group.Key.EmpDept + " " 
            + languages;
    }
