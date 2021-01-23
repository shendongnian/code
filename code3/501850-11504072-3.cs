    void EnableUser(string computer, string user)
    {
        var objectName = "WinNT://" + computer + "/" + user + ",user";
        dynamic objUser = Activator.CreateInstance(Type.GetTypeFromProgID(objectName));
        // Enable the user.
        objUser.AccountDisabled = true;
        objUser.SetInfo();
    }
