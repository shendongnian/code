    public JsonResult GetChart(int employeeId)
    {
        var query = (from e in db.EmployeeDetails
                    join b in db.Bugs on e.EmployeeId == b.CreatedById
                    join p in projects on b.ProjectId == p.ProjectId
                    where e.EmployeeId == employeeId
                    group new {p, b} by new {
                        p.ProjectName
                    }
                    select new {
                        Project = g.Key.Name,
                        Bugs = g.Count()
                    }).Take(50);
        return Json(query.ToList(), JsonRequestBehaviour.AllowGet);
    }
