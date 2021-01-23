    var sha384Factory = HmacFactory;
    var random = new CryptoRandom();
    byte[] derivedKey
    string hashedPassword = null;
    string passwordText = "foo";
    byte[] passwordBytes = SafeUTF8.GetBytes(passwordText);
    var salt = random.NextBytes(384/8);
   
    using (var pbkdf2 = new PBKDF2(sha384Factory, passwordBytes, salt, 256*1000))
        derivedKey=  pbkdf2.GetBytes(384/8);
    using (var hmac = sha384Factory()) 
    {
        hmac.Key = derivedKey;
        hashedPassword = hmac.ComputeHash(passwordBytes).ToBase16();
    }
