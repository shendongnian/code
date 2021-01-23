    protected void griditems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = table;
            if (dt.Rows.Count > 0)
            {
                dt.Rows.RemoveAt(e.RowIndex);
                griditems.DataSource = dt;
                BindData();
            } 
        }
