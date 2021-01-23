    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = e.Row.FindControl("LinkButtonPO") as LinkButton;
                CheckBox cb = e.Row.FindControl("CbPO") as CheckBox;
                if (cb != null)
                    {
                        cb.Visible = false;
                    }
            }
        }
