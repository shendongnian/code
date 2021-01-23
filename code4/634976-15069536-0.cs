    var query = from a in MyTable
                group a by new { 
                  a.Paypoint,
                  a.Department,
                  a.EmployeeCode,
                  a.Gender, 
                  a.Surname
                } into g
                select g.OrderByDescending(x => x.ItemsIssuedDate)
                      //.Select(x => new { required properties })
                        .First();      
