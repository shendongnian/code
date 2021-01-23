    void EnableUser(string computer, string user)
    {
        dynamic objUser = GetObject("WinNT://" & computer & "/" & user & ",user");
        // Enable the user.
        objUser.AccountDisabled = true;
        objUser.SetInfo();
    }
