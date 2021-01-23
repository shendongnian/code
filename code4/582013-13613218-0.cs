        foreach (GridViewRow r in GridViewServer.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                string architecture = ((AjaxControlToolkit.ComboBox)r.FindControl("ComboBox1")).Text;
            }
        }
