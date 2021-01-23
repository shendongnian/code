    DataTable dt1 = new DataTable();
    DataRow dr1;
    dt1.Columns.Add("ProjectID");
    dt1.Columns.Add("ProjectName");
    dt1.Columns.Add("Country");
    for (int i = 0; i < 10; i++)
    {
         dr1 = dt1.NewRow();
         dr1["ProjectID"] = dr1["ProjectName"] = dr1["Country"] = "";
         dt1.Rows.Add(dr1);
    }
    dt1.AcceptChanges();
    ProjectListGridView.DataSource = dt1;
    ProjectListGridView.DataBind();
