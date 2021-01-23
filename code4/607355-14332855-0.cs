    BtnLogin_click()
    {
            // Query database to check username/password match
            // If Success store corresponding UserID in session
            Session["userID"]=YourDbValue;   // Say 1 is for administrator, 2 is for user
    }
