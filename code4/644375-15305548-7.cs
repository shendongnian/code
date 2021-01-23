    List<EmployeeProject> employeeProjects = new List<EmployeeProject>();
    employeeProjects
            .Where(et => compareProjectNames.Contains(et.Project.Name))
            .GroupBy(cust => cust.Project.Name) //groups them by name, so no need to order
            .Select(grp => grp.First()) //selects the first distinct name per group
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
