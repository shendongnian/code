    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton link = new LinkButton();
                link.Text = e.Row.Cells[0].Text;
                link.CommandArgument = "Hello";
                e.Row.Cells[0].Controls.Add(link);
            }
        }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           string value = e.CommandArgument.ToString();
           TextBox1.Text=value;
        }
