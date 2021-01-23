    var r1 = (from a in Context.Employees
              where a.DepartmentID == DepartmentID
              && (a.GroupID == null || a.GroupID == 0)
              select new Group()
              {
                ID = Convert.ToInt32(a.DepartmentID * 10000),
                Name = "",
                DepartmentID = a.DepartmentID
              }
             ).Take(1);
    var r2 = (from a in Context.Groups
              select new Group()
              {
                ID = a.GroupID,
                Name = a.GroupName,
                DepartmentID = a.DepartmentID
              }
             );
    var results = r1.Concat(r2); 
