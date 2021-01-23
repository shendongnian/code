    protected void SetSessionTime(string userType)
    {
        if (UserType == "admin")
        {
            Session.Timeout = Int32.Max;
        }
        else
        {
            Session.Timeout = 20;
        }
    }
