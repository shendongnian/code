    public DataTable CreateNewRow(DataTable ResultsTable, string SubHead, 
                                               string SubHeader, string SubHeadValue)
    {
        DataRow shRow = ResultsTable.NewRow();
        shRow["a"] = SubHead;
        shRow["b"] = SubHeader;
        shRow["c"] = SubHeadValue;
        ResultsTable.Rows.Add(shRow);
        return ResultsTable; 
    }
    using(DataTable ResultsTable = CreateNewRow(ds.Tables[0], "SubHead", "Wheel Subs", 
                                                                      totalWheels))
    {
          //Your logic
    }
