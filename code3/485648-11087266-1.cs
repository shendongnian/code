     protected void GridViewRowEventHandler(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label flag = (Label)e.Row.FindControl("process_Flags");
                if (flag.Text == "A")
                {
                    StatusDD.SelectedValue = "A";
                }
                if (flag.Text == "B")
                {
                    StatusDD.SelectedValue = "B";
                }
                //etc...
            }          
        }
