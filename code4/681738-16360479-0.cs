    var newRows = dt.AsEnumerable()
                    .SelectMany(r => r.Field<string>("EHobbies")
                                      .Split(',')
                                      .Select(x => new { No = r.Field<int>("Eno"),
                                                         Hobbies = x,
                                                         Sal = r.Field<int>("Esal") }
                                             )
                               );
    
    DataTable result = new DataTable("EmployeeTable");
    result.Columns.Add("Eno", typeof(int));
    result.Columns.Add("EHobbies", typeof(string));
    result.Columns.Add("Esal", typeof(int));
    
    foreach(var newRow in newRows)
        result.Rows.Add(newRow.No, newRow.Hobbies, newRow.Sal);
