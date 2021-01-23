    public UserAccount GetUserAccount(string username)
    {
        using (var context = new PrincipalContext(ContextType.Domain))
        using (var user = UserPrincipal.FindByIdentity(context, username))
        {
            return new UserAccount
            {
                Id = user.Guid,
                FullName = user.Name,
                Password = "FORGET ABOUT IT, YOU CAN'T RETRIEVE THE PASSWORD",
                EmployeeId = user.EmployeeId
            };
        }
    }
