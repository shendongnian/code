    DataTable dtStatusDetails = new DataTable();
        dtStatusDetails.Columns.Add("D1", typeof(string));
        dtStatusDetails.Columns.Add("D2", typeof(string));
    dtStatusDetails.Rows.Add(
        data1.Value.ToString(),
        data2.Value.ToString(),
    );
