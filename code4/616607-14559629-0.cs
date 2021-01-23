    int origRowCount = AlldaysList.Rows.Count;
    for (int i = 0; i < origRowCount; i++)
    {
        for (int j = 1; j <= 3; j++)
        {
            AlldaysList.Rows.InsertAt(MakeNewAlldaysRow(AlldaysList), i * 4 + j);
        }
    }
    // ....
    // (separate method)
    static DataRow MakeNewAlldaysRow(DataTable table)
    {
        DataRow row = table.NewRow();
        row["scenarionid"] = DBNull.Value;
        row["description"] = "";
        return row;
    }
