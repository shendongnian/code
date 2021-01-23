    DataTable newDt = new DataTable();
    //Select indexes
    var indexes = dt.Rows.Cast<DataRow>().Select(row => dt.Rows.IndexOf(row));
    //Select the columns
    var newCols = indexes.Select(i => "Row" + i);
    //Add columns
    foreach(var newCol in newCols)
    {
      newDt.Add(newCol);
    }
    //Select rows
    var newRows = dt.Rows.Cast<DataColumn>().Select(col =>
                                                      {
                                                        row = newDt.NewRow();
                                                        foreach(int i in indexes)
                                                        {
                                                          row[i] = dt.Rows[i][col.Name];
                                                        }
                                                        return row;
                                                      });
    //Add row to new datatable
    foreach(var row in newRows)
    {
      newDt.Add(row);
    }
