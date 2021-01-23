    DataTable dt = new DataTable();
    dt.Columns.Add("Spots");
    dt.Columns.Add("CompanyName");
    int i = 0;
    while(i<10)
    {
       DataRow dr = dt.NewRow();
       dr["Spots"] = "";
       dr["CompanyName"] = "";
       dt.Rows.Add(dr);
       i++;
    }
    MyGrid.DataSource = dt;
    MyGrid.DataBound();
