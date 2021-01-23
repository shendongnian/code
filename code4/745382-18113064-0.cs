    var distinctValues = (from a in dataContext.A_Table
                          join b in dataContext.B_Table
                          on a.EmpID equals b.EmpID
                          join c in dataContext.C_Table
                          on b.SomeID equals c.ID
                          where a.IsActive == true
                          && a.ID == id
                          select new NewClass()
                          {
                              ID = c.ID,
                              Name = c.Name
                          }).ToList().Select(x=>x.Name).Distinct();
