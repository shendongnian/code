      var dt = new DataTable();
      dt.Columns.Add("SomeDateField");
      dt.Columns.Add("OtherField");
      dt.Columns.Add("AnotherOtherField");
      dt.Rows.Add(DateTime.Now, "Test", "Test");
      var rowStrings = dt.Rows.Cast<DataRow>().Select(x => String.Join(@"\", dt.Columns.Cast<DataColumn>().Select(y =>
      {
        DateTime dateOut = new DateTime();
        if (DateTime.TryParse(x[y.ColumnName].ToString(), out dateOut))
          return dateOut.ToShortDateString();
        else
          return x[y.ColumnName];
      }).ToArray())).ToList();
