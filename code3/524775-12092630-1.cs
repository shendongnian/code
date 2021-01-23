    public JsonResult Getchart(int employeId)
      {
            var Bug = db.Bugs.ToList<Bug>();
            var EmployeDetails = db.EmployeeDetails.ToList<EmployeeDetail>();
            var projects = db.Projects.ToList<Project>();
           var result =   (from e in EmployeDetails 
                          join b in Bug on e.EmployeId equals b.CreatedByID
                          join p in projects on b.ProjectId equals p.ProjectId
                          where e.EmployeId == employeeId
                          group p.projectName
                         select new (p.projectName as Project ,count(b.CreatedByID) as Bug)).Take(50);
                           return Json(result,JsonRequestBehavior.AllowGet);
         }
