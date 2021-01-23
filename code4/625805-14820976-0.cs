    var query = context.CheckIns
                   .Where(p => p.DepartmentId == departmentId && p.Created.Date == date)
                   .GroupBy(r => r.PersonId)
                   .Select(g => g.OrderByDescending(p => p.Created).First())
                   .Join(context.Persons, c => c.PersonId, p => p.Id, 
                            (c,p) => new { p.Name, c.Id, c.Status, c.Created, c.DepartmentId})
                   .OrderByDescending(f => f.Name);
