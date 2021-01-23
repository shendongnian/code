        var list = new List<Employee>();
        var id = table.Columns[0];
        var marks = table.Columns.Cast<DataColumn>().Skip(1).ToArray();
        foreach (DataRow row in table.Rows)
        {
            var obj = new Employee { EmpId = (int) row[id] };
            var dict = new Dictionary<string,decimal>();
            foreach (var mark in marks)
            {
                dict[mark.ColumnName] = (decimal)row[mark];
            }
            obj.SubjectMarks = dict;
            list.Add(obj);
        }
