    DataColumn[] subjectColumns = table.Columns.Cast<DataColumn>().Skip(1).ToArray();
    List<Employee> employee = table.AsEnumerable()
        .Select(r => new Employee
        {
            EmpId = r.Field<int>("Employee"),
            SubjectMarks = subjectColumns.Select(c => new
            {
                Subject = c.ColumnName,
                Marks   = r.Field<decimal>(c)
            })
            .ToDictionary(x => x.Subject, x => x.Marks)
        }).ToList();
