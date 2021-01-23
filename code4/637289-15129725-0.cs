    DataTable dt = GetDataSourceTable();
    Session["RowsCount"] = dt.Rows.Count;
    Session["DataTable"] = dt; //Should be avoided since session are per user. 
    gridView.DataSource = dt;
    gridView.DataBind();
