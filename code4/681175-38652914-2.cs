    var user = GetUserByUserName("bob")
    var sha384Factory = HmacFactory;
    byte[] derivedKey
    string hashedPassword = null;
    string suppliedPassword = "foo";
    byte[] passwordBytes = SafeUTF8.GetBytes(suppliedPassword);
   
    using (var pbkdf2 = new PBKDF2(sha384Factory, passwordBytes, user.UserSalt, 256*1000))
        derivedKey=  pbkdf2.GetBytes(384/8);
    using (var hmac = sha384Factory()) 
    {
        hmac.Key = derivedKey;
        hashedPassword = hmac.ComputeHash(passwordBytes).ToBase16();
    }
    isAuthenticated = hashedPassword == user.UserHashedPassword; //true for bob
