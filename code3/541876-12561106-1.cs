    var query = (from user in dwe.UsersTable 
                            where user.LoginName.Equals(usernameBox.Text) && 
                            user.Password.Equals(pwBox.Text)
                             select user).FirstOrDefault();
    
    if(query!=null)
    {
       Session["User"] = query.UserID; 
       Response.Redirect("Edit.aspx"); 
    }
    else
    {
       LabelError.Text = "Error try again";
    }
