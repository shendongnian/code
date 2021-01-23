    public JsonResult Getchart(int employeeId)
    {
        var Bug = db.Bugs.ToList<Bug>();
        var EmployeeDetails = db.EmployeeDetails.ToList<EmployeeDetail>();
        var projects = db.Projects.ToList<Project>();
        
        var result = (from e in EmployeeDetails 
                      join b in Bug on e.EmployeeId equals b.CreatedByID
                      join p in projects on b.ProjectId equals p.ProjectId
                      where e.EmployeeId = employeeId   // <-- use the parameter here
                      group p by p.projectName into g
                      select new {
                         Project = g.Key,
                         Bug = g.Count() 
                         }
                     ).Take(50);
        return Json(result,JsonRequestBehavior.AllowGet);
    }
