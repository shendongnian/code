    protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (Login1.UserName == "SomeUser1" && Login1.Password == "password123")
        {
            e.Authenticated = true;
        }
    
        else
        {
            e.Authenticated = false;
        }
    }
    
    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {
        Session["PersonPID"] = con.GetPerson(Login1.UserName).PID;
        Session["PersonFirstName"] = con.GetPerson(Login1.UserName).FirstName;
        Session["PersonLastName"] = con.GetPerson(Login1.UserName).LastName;
        Session["PersonDob"] = con.GetPerson(Login1.UserName).Dob;
        Session["PersonTown"] = con.GetPerson(Login1.UserName).Town;
        Session["PersonGender"] = con.GetPerson(Login1.UserName).Gender;
        Session["PersonUname"] = Login1.UserName;
        Session["PersonImageUrl"] = con.GetPerson(Login1.UserName).ImageUrl;
        Session["PersonPres"] = con.GetPerson(Login1.UserName).Pres;
    }
