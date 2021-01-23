    var encryptedPassword = MembershipProvider.EncryptPassword(password);
    int numberOfReuse = 5;  // or configurable
    var historiesQuery = (from histories in dataContext.GetTable<PasswordHistory>()
                          where histories.UserId == userId
                          orderby histories.PasswordDate descending
                          select histories.Password).Take<string>(numberOfReuse);
    return historiesQuery.Contains<string>(enycryptedPassword);
