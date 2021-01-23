    System.Data.DataTable table = // your table 
    List<Employee> result =
        table.AsEnumerable().Select(i => new Employee()
            {
                EmpId = i.Field<int>("Employee"),
                SubjectMarks = { { "subject1", i.Field<decimal>("subject1") } ,
                                 { "subject2", i.Field<decimal>("subject2") } ,
                                 { "subject3", i.Field<decimal>("subject3") } }
            }).ToList();
