      public DataTable getdatw()
    {
        DataTable dtExcel = new DataTable();
        dtExcel.Columns.Add("Id", typeof(Int32));
        dtExcel.Columns.Add("Name", typeof(String));
        DataRow row;
        row = dtExcel.NewRow();
        row["Id"] = "1";
        row["Name"] = "kamal";
        dtExcel.Rows.Add(row);
        return dtExcel;
    }
