    var query = from a in context.EMPLOYEE_SPECIALTIES.ToList()
                group a by a.EMPLOYEE_ID into g
                select new 
                {
                    EmployeeId = g.Key,
                    SpecialtyCode = string.Join(",", g.Select(x =>  
                    x.SPECIALTY_CODE))
                };
    
    var query2 = (from a in query
                  join b in context.EMPLOYEEs on a.EmployeeId equals b.EMPLOYEE_ID
                  select new EmployeeSpecialtyArea
                  {
                      EmployeeId = b.EMPLOYEE_ID,
                      LastName = b.LAST_NAME,
                      SpecialtyCode = a.SpecialtyCode
                  });
    
    ViewBag.EmployeeSpecialtyArea = query2;
