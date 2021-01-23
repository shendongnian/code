    void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Entity entity = e.Row.DataItem as Entity;
                LinkButton lnkTest = e.Row.FindControl("lnkTest") as LinkButton;
                lnkTest.CommandArgument = entity.ID.ToString();
                lnkTest.Text = entity.Name;
            }
        }
