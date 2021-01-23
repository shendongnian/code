    public override bool ValidateUser(string username, string password)
    {
        // check in database with SqlmembershipProvider
        bool isValid = base.ValidateUser(username, password);
        // get user from database
        var user = Membership.GetUser(username);
        if(isValid)
        {
            // ...
        }
        else{
            // log wrong attempt if you want
        }
        return isValid;
    }
     
