    DataTable newDt = new DataTable();
    newDt.Columns.Add("Eno", typeof(int));
    newDt.Columns.Add("EHobbies", typeof(string));
    newDt.Columns.Add("Esal", typeof(int));
    dt.AsEnumerable().ToList()
                     .ForEach(row => row["EHobbies"].ToString().Split(',').ToList()
                     .ForEach(item => newDt.Rows.Add(row["Eno"], item, row["Esal"])));
