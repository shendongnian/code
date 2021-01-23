    int total = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if(e.Row.RowType==DataControlRowType.DataRow)
    {
    total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
    }
    if(e.Row.RowType==DataControlRowType.Footer)
    {
    Label lblamount7 = (Label)e.Row.FindControl("lblTotal");
    lblamount7.Text = total.ToString();
    }
    }
