 {
       
        DataTable dt = (DataTable)Session["dt"];
        GridViewRow row =res.Rows[e.RowIndex];
        res.Visible = false;
        dt.Rows[row.DataItemIndex]["name"] = ((LinkButton)(row.Cells[1].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["dewey"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["subject"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
        res.DataBind();
    }
