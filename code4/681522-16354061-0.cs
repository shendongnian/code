    public bool ValidateUser(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName) || userName.Length > 128 ||
    	string.IsNullOrWhiteSpace(password) || password.Length > 256)
        {
    	    throw new ProviderException("Username and password are required");
        }
    
        var user = this.db.Users.SingleOrDefault(u => u.UserName == userName);
    
        if (user == null || !PasswordHash.Validate(password, user.PasswordHash, user.PasswordSalt))
        {
    	    throw new ProviderException("Incorrect password or username");
        }
    
        return true;
    }
