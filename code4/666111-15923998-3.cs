    protected void grddata_RowDataBound(object sender, GridViewRowEventArgs e)
        {    
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ID = Convert.Int32(DataBinder.Eval(e.Row.DataItem, "ID"));
                HyperLink hyp = (HyperLink)e.Row.FindControl("hyp");
                hyp.NavigateUrl = "Test.aspx?Name='" + Request.QueryString["test"] + "'&&ID"+ ID +"";
            }
        }
