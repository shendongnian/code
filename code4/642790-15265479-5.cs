    protected void Review_grid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //find ListBox
                    ListBox lst = (ListBox)e.Row.FindControl("lstBox");
                    lst.Items.Add(new ListItem("item1"));
                    lst.Items.Add(new ListItem("item2"));
                    lst.Items.Add(new ListItem("item3"));
    
                    //find textBox
                    TextBox txt = (TextBox)e.Row.FindControl("txtBox");
                    txt.Text = "test";
    
                }
            }
