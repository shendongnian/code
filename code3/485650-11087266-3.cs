     protected void GridViewRowEventHandler(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               Label flag = (Label)e.Row.FindControl("process_Flags");
               DropDownList ddl = (DropDownList)e.Row.FindControl("StatusDD");
                if (flag.Text == "A")
                {
                    ddl.SelectedValue = "A";
                }
            //add more conditions here..
            }          
        }
