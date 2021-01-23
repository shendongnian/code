    List<EmployeeProject> employeeProjects = new List<EmployeeProject>();
    employeeProjects
            .Where(et => compareProjectNames.Contains(et.Project.Name))
            .GroupBy(cust => cust.Project.Name)
            .Select(grp => grp.First())
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
