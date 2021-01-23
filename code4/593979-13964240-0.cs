            var q1 = 
                     from d in ctx.Departments 
                     from o in ctx.Offices.Where(o => o.DepartmentId == d.Id).DefaultIfEmpty()
                     from e in ctx.Employees.Where(e =>  e.OfficeId == o.Id).DefaultIfEmpty()
                     group e by d into de
                     select new {
                        DepartmentName = de.Key.Name,
                        AverageAge = de.Average(e => e == null ? 0 : e.Age),
                     };
