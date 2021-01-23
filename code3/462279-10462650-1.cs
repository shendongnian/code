      void GrdViewUsers_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
        if(e.CommandName=="Edit")
        {
            int index = Convert.ToInt32(e.CommandArgument);      
            GridViewRow row = GrdViewUsers.Rows[index];
            // now you can get all of your controls like:
            Label lblSurname = (Label)row.FindControl("lblSurname");
            String email = lblSurname.Text // you noticed that DataItem.Email is bound to lblSurname?
        }
      }  
  
