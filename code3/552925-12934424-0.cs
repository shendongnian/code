    var list = new List<int> { 1, 2, 3, 4, 5 };
    
    List<StudentQuery> result = (from r in oStudentDataTable.AsEnumerable()
                  where (list.Contains(r.Field<int>("ID"))
                  select new StudentQuery
                  { /*
                    .Your entity here
                    .
                    */
                  }).ToList<StudentQuery>();
