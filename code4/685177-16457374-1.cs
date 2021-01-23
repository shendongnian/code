    var r1 = (from a in Context.Employees
              where a.DepartmentID == DepartmentID
              && (a.GroupID == null || a.GroupID == 0)
              select new Group()
              {
                GID = Convert.ToInt32(DepartmentID * 10000),
                GName = "",
                DID = a.DepartmentID
              }
             );
    var r2 = (from a in Context.Groups
              select new Group()
              {
                GID = a.GroupID,
                GName = a.GroupName,
                DID = DepartmentID
              }
             );
    var results = r1.Concat(r2); 
