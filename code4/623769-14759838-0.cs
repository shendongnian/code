    DataTable myTable = new DataTable();
    myTable.Columns.Add("PilotID");
    myTable.Columns.Add("Start_date");
    myTable.Columns.Add("End_date");
    myTable.Columns.Add("Hours");
    DataRow dr = myTable.NewRow();
    dr["PilotID"] = 1;
    myTable.Rows.Add(dr);
    myTable.Rows[0]["PilotID"] = 1;
