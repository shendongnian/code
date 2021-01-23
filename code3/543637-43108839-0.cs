            DataSourceSelectArguments dss = new DataSourceSelectArguments();
            SqlDataSource sds = (SqlDataSource)YourControl.FindControl("your datasource control");
            if (sds != null)
            {
                DataView dv = (DataView)sds.Select(DataSourceSelectArguments.Empty);
                if (dv != null)
                {
                    DataTable dt = (DataTable)dv.ToTable();
                    if (dt != null)
                    {
                      myGridView.DataSource = dt;
                      myGridView.DataSourceID = null; //won't be needed
                      myGridView.DataBind();
    etc
