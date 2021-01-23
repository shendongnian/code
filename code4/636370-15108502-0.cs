    byte[] output = Encrypt(EncryptBufferInput);
    string encryptedOutput = Encoding.ASCII.GetString(output);
    str.Append(encryptedOutput);
    
    byte[] decrypted = Decrypt(encryptedOutput);
    string decryptedOutput = Encoding.ASCII.GetString(decrypted);
    str.Append(decryptedOutput);
