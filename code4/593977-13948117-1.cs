		were you meaning something along the lines of:
    var newQ2 = from d in ctx.Departments
                     outer left join o in ctx.Offices on d.Id equals o.DepartmentId
                     outer left join e in ctx.Employees on o.Id equals e.OfficeId
                     group e by d into de
                     select new {
                        DepartmentId = de.Key.Id,
                        AverageAge = de.Count() == 0 ? 0 : de.Average(e => e.Age),
                     };
