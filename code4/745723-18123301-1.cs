    string password = "shortstring";
    byte[] salt = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }; // this is fixed... It would be better you used something different for each user
    
    // You can raise 1000 to greater numbers... more cycles = more security. Try
    // balancing speed with security.
    Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(password, salt, 1000);
    
    // generate key
    byte[] key = pwdGen.GetBytes(16);
