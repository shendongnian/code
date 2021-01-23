    string password = "P@$$w0rd";
    byte[] salt = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }; // this is fixed... It would be better you used something different for each user
    // You can raise 1000 to greater numbers... more cycles = more security. Try
    // balancing speed with security.
    Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(password, salt, 1000);
        
    // generate key and iv
    byte[] key = pwdGen.GetBytes(16);
    byte[] iv = pwdGen.GetBytes(16);
    byte[] encrypted;
    {
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        rijndaelCipher.Key = key;
        rijndaelCipher.IV = iv;
        // Or your data
        byte[] data = System.Text.Encoding.UTF8.GetBytes("hello world");
        var encryptor = rijndaelCipher.CreateEncryptor();
        encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);
    }
    {
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        rijndaelCipher.Key = key;
        rijndaelCipher.IV = iv;
        var decryptor = rijndaelCipher.CreateDecryptor();
        byte[] decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
        
        // this if you are encrypting text, otherwise decrypted is already your data
        string text = System.Text.Encoding.UTF8.GetString(decrypted);
    }
