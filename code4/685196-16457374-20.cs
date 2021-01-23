    int deptID = 99;
    string key = "foo";
    var r1 = (from a in Context.Employees
              where a.DepartmentID == deptID
              && (!a.GroupID.HasValue || a.GroupID == 0)
              select new Group()
              {
                ID = a.DepartmentID * 10000,
                Name = string.Empty,
                DepartmentID = a.DepartmentID
              }
             ).Take(1);
    var r2 = (from a in Context.Groups
              where a.DepartmentID == deptID
              select new Group()
              {
                ID = a.GroupID,
                Name = a.GroupName,
                DepartmentID = a.DepartmentID
              }
             );
    var results = r1.Concat(r2); // UNION ALL the above 2 sets of results
