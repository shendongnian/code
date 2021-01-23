    private void AddNewRow()
    {           
        DataTable dt = new DatatTable(); 
        dt.Columns.Add("sno");
        dt.Columns.Add("name");
        foreach (GridViewRow gvRow in gvCommissions.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["sno"] = ((Label)gvRow.FindControl("lblSno")).Text;
            dr["name"] = ((Label)gvRow.FindControl("txtName")).Text;
            dt.Rows.Add(dr);
        }
        DataRow dr1 = dt.NewRow();
        dr1["sno"] = "";
        dr1["name"] = "";
        dt.Rows.Add(dr1);
        gvCommissions.DataSource = dt;
        gvCommissions.DataBind();
    }
