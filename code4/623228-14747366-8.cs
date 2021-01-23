    protected DataTable GetDataTable()
    {
        DataTable dt;
        if (Session["CurrentData"] != null)
        {
            dt = (DataTable)Session["CurrentData"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("First Name", typeof(String));
            dt.Columns.Add("Last Name", typeof(String));
            Session["CurrentData"] = dt;
        }
        return dt;
    }
