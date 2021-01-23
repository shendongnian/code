    const string format = "D";
    Func<DataRow, int, string> formatter = 
      (DataRow row, int index) => row.Field<double>(index).ToString(format);
    foreach (DataRow row in popula.AsEnumerable())
    {
      var item = listView1.Items.Add(formatter(row, 0));
      
      for (int i = 1; i <= 4; i++)
      {
        item.SubItems.Add(formatter(row, i));
      }
    }
