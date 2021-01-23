    String GetEncryptedPassword (String prmUser, String prmPassword)
    {
        // Concatenating the password and user name.
        String encryptedPassword = prmUserName + prmPassword;
                
        // Converting into the stream of bytes.
        Byte[] passInBytes = Encoding.UTF8.GetBytes(encryptedPassword);
            
        // Encrypting using SHA1 encryption algorithm.
        passInBytes = SHA1.Create().ComputeHash(passInBytes);
                
        // Formatting every byte into %03d to make a fixed length 60 string.
        return passInBytes.Aggregate(String.Empty, (pass, iter) => pass += String.Format("{0:000}", iter));
    }
