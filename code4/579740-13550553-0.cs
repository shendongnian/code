    DataTable dt = new DataTable();
    dt.Columns.Add("id", Type.GetType("System.Int32"));
    dt.Columns.Add("Colum1", Type.GetType("System.Int32"));
    dt.Columns.Add("Colum2", Type.GetType("System.String"));
    dt.Columns.Add("Colum3");
    string[] colsNames = new[] { "Colum1", "Colum2" };
    var colTypes = dt.Columns.Cast<DataColumn>()
                     .Where(c => colsNames.Contains(c.ColumnName))
                     .Select(c => new
                     {
                         c.ColumnName,
                         c.DataType
                     })
                     .ToDictionary(key => key.ColumnName, val => val.DataType);
    var query = dt.AsEnumerable()
                  .Where(row => (int)row["id"]==5)
                  .Select(row => new
                  {
                      Colum1 = Convert.ChangeType(row[colsNames[0]], colTypes[colsNames[0]]),
                      Colum2 = Convert.ChangeType(row[colsNames[1]], colTypes[colsNames[1]])
                  });
