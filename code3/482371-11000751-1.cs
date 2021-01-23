    public DataTable CreateNewRow(DataTable ResultsTable, String ColumnA, 
          String ColumnB, String ColumnC, String ColumnAVal, String ColumnBVal, 
          String ColumnCVal)
    {
        DataRow shRow = ResultsTable.NewRow();
        shRow[ColumnA] = ColumnAVal;
        shRow[ColumnB] = ColumnBVal;
        shRow[ColumnC] = ColumnCVal;
        ResultsTable.Rows.Add(shRow);
        return ResultsTable; 
    }
    using(DataTable ResultsTable = CreateNewRow
                                   (
                                      ds.Tables[0], 
                                      "a",
                                      "b",
                                      "c",
                                      "SubHead", 
                                      "Wheel Subs", 
                                      totalWheels
                                   ))
    {
          //Your logic
    }
