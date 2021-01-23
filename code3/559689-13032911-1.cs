    var allAsString = dtOutput.AsEnumerable()
        .SelectMany((r, ri) => r.ItemArray
                          .Select((f, fi) => new
                          {
                              Row = r,
                              RowNumber = ri,
                              Col = table.Columns[fi],
                              Field = string.Format("{0}", f)
                          }));
    foreach (var param in allAsString)
    {
        DataColumn Column = param.Col;
        String Text = param.Field;
        DataRow Row = param.Row;
        int RowNumber = param.RowNumber;
    }
