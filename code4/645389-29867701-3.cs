    public void UpdatePasswordAndEmail(long userId, string password, string email)
    {
        var user = new User {UserId = userId, Password = password, Email = email};
        Update(user, u => u.Password, u => u.Email);
        Save();
    }
