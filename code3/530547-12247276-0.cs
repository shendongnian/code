    protected void myGV_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "click1")
            {
                int index = Convert.ToInt32(e.CommandArgument); //get row number selected
                GridViewRow row = GridView1.Rows[index]; 
                Go ahead do something like above 
    
            }
    
            if (e.CommandName == "click2")
            {
                Do something cool ... 
            }
        }
