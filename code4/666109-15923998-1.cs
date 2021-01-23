    protected void grddata_RowDataBound(object sender, GridViewRowEventArgs e)
        {    
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hyp = (HyperLink)e.Row.FindControl("hyp");
                hyp.NavigateUrl = "Test.aspx?Name='" + Request.QueryString["test"] + "'";
            }
        }
