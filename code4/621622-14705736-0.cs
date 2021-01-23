    if (!UserList.Any(x => x.Type == (int)UserType.SuperUser))
    {
        AesCrypto aesCrypto = new AesCrypto();
        user newuser = new user();
        newuser.username = DEFAULT_SUPER_USER_NAME;
        newuser.password = aesCrypto.Encrypt(DEFAULT_SUPER_USER_PASSWORD);
        newuser.type = (int)UserType.SuperUser;
        newuser.create_date = DateTime.Now;
        newuser.last_login = newuser.create_date;
        newuser.email_address = DEFAULT_SUPER_USER_EMAIL_ADDR;
        newuser.login_count = 1;
    
        DatabaseContext.Users.Add(newuser);
        if (!DatabaseContext.Save())
            return false;
    }
