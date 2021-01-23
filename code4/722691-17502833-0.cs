     protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
           gv.EditIndex = e.NewEditIndex;
            gvBind();
        }
    
     protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv.EditIndex = -1;
            gvBind();
        }
