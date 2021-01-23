    private int total = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) 
        { 
            total += Convert.ToInt32(((DataRowView)e.Row.DataItem)["total"].ToString()); 
        } 
        if (e.Row.RowType == DataControlRowType.Footer) 
        { 
            Label lblamount7 = (Label)e.Row.FindControl("Label27"); 
            lblamount7.Text =total.ToString(); 
        }
    }
