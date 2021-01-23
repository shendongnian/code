    private void grdCoboFill()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ColorID", typeof(int));
        dt.Columns.Add("ColorName", typeof(String));
        dt.Rows.Add(new Object[] { 1, "RED" });
        dt.Rows.Add(new Object[] { 2, "GREEN" });
        dt.Rows.Add(new Object[] { 3, "BLUE" });
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            ((DropDownList)row.FindControl("DropDownList1")).DataSource = dt;
            ((DropDownList)row.FindControl("DropDownList1")).DataValueField = "ColorID";
            ((DropDownList)row.FindControl("DropDownList1")).DataTextField = "ColorName";
            ((DropDownList)row.FindControl("DropDownList1")).DataBind();
        }
    }
