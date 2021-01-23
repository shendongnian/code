    protected void gvParent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = (GridView)e.Row.FindControl("gvChild");
                gvChild.DataSource = GetData();
                gvChild.DataBind();
            }
        }
    
        protected void gvChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ID = ((HiddenField)e.Row.Parent.Parent.Parent.FindControl("HdnID")).Value;
            }
        }
