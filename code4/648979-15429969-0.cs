     from c in allCompanies
     group c by c.Company into departments
     select new {
        Company = departments.Key,
        Departments = from d in departments
                      group d by d.Department into employees
                      select new {
                          Department = employees.Key,
                          Employees = employees.Select(e => e.Employees)
                                               .Distinct()
                      }
     }
