    string salt = "123";
    System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
    byte[] preHash = System.Text.Encoding.UTF8.GetBytes(salt);
    byte[] hash = sha.ComputeHash(preHash);
    
    string password = System.Convert.ToBase64String(hash);
    password = password.Substring(0, 8);
