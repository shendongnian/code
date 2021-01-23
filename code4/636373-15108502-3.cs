    byte[] output = Encrypt(EncryptBufferInput);
    string encryptedOutput = Convert.ToBase64String(output);
    str.Append(encryptedOutput);
    
    byte[] decrypted = Decrypt(output);
    string decryptedOutput = Encoding.ASCII.GetString(decrypted);
    str.Append(decryptedOutput);
