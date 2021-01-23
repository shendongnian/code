    var tblFlattenedStudents = tblStudents.Clone();
    foreach (DataRow row in tblStudents.Rows)
    {
        var names = row.Field<string>("Name").Split('|');
        var ages = row.Field<string>("age").Split('|');
        var profession = row.Field<string>("profession");
        for (int i = 0; i < names.Length; i++)
        {
            var newRow = tblFlattenedStudents.Rows.Add();
            newRow.SetField("Name", names[i]);
            newRow.SetField("age", ages.ElementAtOrDefault(i));
            newRow.SetField("profession", profession);
        }
    }
