    internal static dynamic CreateAccount(bool saveToDatabase, bool useAccessor)
    {
        DateTime created = DateTime.Now;
        string createdBy = _testUserName;
        dynamic account;
    
        if (useAccessor)
             account = new Account_Accessor(created, createdBy);
        else
             account = new Account(created, createdBy);    
    
        account.Notes = Utilities.RandomString(1000);
    
        if (saveToDatabase)
            account.Create();
    }
