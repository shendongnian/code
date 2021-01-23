    public void CreateAccount(string username, string password)
    {
        var salt = Crypto.GenerateSalt();
        var saltedPassword = password + salt;
        var hashedPassword = Crypto.HashPassword(saltedPassword);
        CreateAccount(username, salt, hashedPassword);
    }
            
    public void Verify(string username, string password)
    {
        var salt = GetSaltForUserFromDatabase(username);
        var hashedPassword = GetHashedPasswordForUserFromDatabase(username);
        var saltedPassword = password + salt;
        if (Crypto.VerifyHashedPassword(hashedPassword, saltedPassword))
        {
            // valid password for this username
        }
    }
