    var query = from user in dwe.UsersTable
                where user.LoginName.Equals(usernameBox.Text) 
                      && user.Password.Equals(pwBox.Text)
                select user;
    // get user from query
    // If SingleOrDefault is not supported (<4.0) use FirstOrDefault instead. 
    // Thanks Tim Schmelter
    var user = query.SingleOrDefault(); 
    
    if (user != null)
    {
        Session["UserID"] = user.UserID;                 
        Response.Redirect("Edit.aspx");
    }
    else
    {
        LabelError.Text = "Error try again";
    }
