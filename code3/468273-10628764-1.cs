    String GetEncryptedPassword (String prmUser, String prmPassword)
    {
        // Concatenating the password and user name.
        String encryptedPassword = prmUserName + prmPassword;
                
        // Converting into the stream of bytes.
        Byte[] passInBytes = Encoding.UTF8.GetBytes(encryptedPassword);
            
        // Encrypting using SHA1 encryption algorithm.
        Byte[] hashPassword = SHA1.Create().ComputeHash(passInBytes);
                
        // Formatting first 20 bytes into %03d.
        return hashPassword.Aggregate(String.Empty, (pass, iter) => pass += String.Format("{0:000}", iter));
    }
