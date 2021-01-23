    int deptID;
    string key;
    var r1 = (from a in Context.Employees
              where a.DepartmentID == deptID
              && (a.GroupID == null || a.GroupID == 0)
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
    var results = r1.Concat(r2); 
    var filter = (from e in Context.Employees
                  join g in Context.Groups on g.GroupID equals e.GroupID into eg
                  from subgrp in eg.DefaultIfEmpty()
                  where e.DepartmentID == deptID
                  && (e.FirstName + " " + e.LastName).Contains(key)
                  select new Group()
                  {
                    ID = e.GroupID,
                    Name = (e.GroupID == 0 || e.GroupID == null) ? string.Empty, subgrp.GroupName
                    DepartmentID = e.DepartmentID
                  }
                 ).Distinct();              
              
    results = from a in results
              join g in filter on g.Name = a.Name
              orderby a.Name descending
              select a;   
