    //Move inside the method call if you need it to be dynamic.
    private readonly string[] compareProjectNames = new[]
    { 
       "AccountingX 11", "TopX 2", "SiteX 32", 
       "BuildingX 3", "ReportX 321", "PrototypeX 78"
    };
    private IQueryable<EmployeeProject> GetEmployeeProjects()
    {
        var employeeProjects =  service.CustomQuery<EmployeeProject>()
            .Where(et => compareProjectNames.Contains(ep.Project.Name))
            .OrderBy(ep => ep.Employee.Name)
            .Select(ep => new EmployeeProject
            {
                Id = ep.Id,
                Project = new Project
                {
                    Name = ep.Project.Name
                },
                Employee = new Employee
                {
                    Id = ep.Employee.Id,
                    Name = ep.Employee.Name
                }
            });
        return employeeProjects;
    }
