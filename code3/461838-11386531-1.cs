    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       // note that this is the command we assign to save button. 
       // we use it here to capture which button was clicked.
        if (e.CommandName == "SaveData")
        {
            TextBox txtFirstName = e.Item.FindControl("txtFirstName") as TextBox;
            string fname= txtFirstName.Text;
            
           // do somethig with your date here..
            
        }
    }
