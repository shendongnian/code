    private static Account GetByName(string accountName, bool activatedOnly = false)
    {
        using (var context = new DBEntities())
        {
            return context.Accounts.FirstOrDefault(s => 
                s.AccountName == accountName &&
                s.IsApproved == activatedOnly);
        }
    }
    
    public static Account Get(string accountName, string password)
    {
        var account = GetByName(accountName, true);
        if (account != null)
            if (!Cryptographer.IsValidPassword(password, 
                                               account.PasswordSalt, 
                                               account.PasswordKey))
                return null;
        return account;
    }
