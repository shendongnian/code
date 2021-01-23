    public JsonResult GetChart()
                {
                    //int employeeId
                  var Bug = db.Bugs.ToList<Bug>();
                  var EmployeDetails = db.EmployeeDetails.ToList<EmployeeDetail>();
                  var projects = db.Projects.ToList<Project>();
    
                  var query = (from e in EmployeDetails
                               join b in Bug on e.EmployeId equals b.CreatedByID
                               join p in projects on b.ProjectId equals p.ProjectId
                               where e.EmployeId == 1
                               group new { p, b } by new
                               {
                                   p.projectName
                               } into g
                               select new ChartModel
                               {
                                   ProjectName = g.Key.projectName,                     
                                    
                                   bug = g.Count()
                               }).ToList();
                  return Json(query, JsonRequestBehavior.AllowGet);
    }
