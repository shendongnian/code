    void EnableUser(string computer, string user)
    {
        dynamic objUser = GetObject("WinNT://" & computer & "/" & user & ",user");
        int i = o.MyMethod();
        // Enable the user.
        objUser.AccountDisabled = True
        objUser.SetInfo()
    }
