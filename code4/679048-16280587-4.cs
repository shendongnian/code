        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
        
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
    //Write code TO UPDATE YOUR DATABESE THEN WRITE BELOW CODE IN LAST
    // To Find Text of TextBox to get updated value....you get it in string like this.
    //string strName = ((TextBox)grdview1.Rows[e.RowIndex].Cells[YourColumnIndexInWhichTexBoxAppear].Controls[0]).Text;
        GridView1.EditIndex = -1;
                GridView1.DataBind();
            }
            protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
                GridView1.EditIndex = -1;
                GridView1.DataBind();
            }
