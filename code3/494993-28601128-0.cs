    static class HappyExtEnding
    {
        public static DataTable ToDataTable<T>(this T [] students)
        {
            if (students == null || students.Length == 0) return null;
            DataTable table = new DataTable();
            var student_tmp = students[0];
            table.Columns.AddRange(student_tmp.GetType().GetFields().Select(field => new DataColumn(field.Name, field.FieldType)).ToArray());
            int fieldCount = student_tmp.GetType().GetFields().Count();
            students.All(student =>
            {
                table.Rows.Add(Enumerable.Range(0, fieldCount).Select(index => student.GetType().GetFields()[index].GetValue(student)).ToArray());
                return true;
            });
            return table;
        }
    }
