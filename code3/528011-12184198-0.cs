    protected void griditems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)Session["table"];
            if (dt.Rows.Count > 0)
            {
                // Replace `10` with the appropriate variable
                dt.Rows.RemoveAt(e.RowIndex + griditems.PageIndex * 10);
                griditems.DataSource = dt;
                BindData();
            }
        }
        catch
        {
            //error message
        }
    }
