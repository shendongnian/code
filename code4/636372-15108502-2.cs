    byte[] output = Encrypt(EncryptBufferInput);
    string encryptedOutput = Convert.ToBas64String(output);
    str.Append(encryptedOutput);
    
    byte[] decrypted = Decrypt(Convert.FromBase64String(encryptedOutput));
    string decryptedOutput = Encoding.ASCII.GetString(decrypted);
    str.Append(decryptedOutput);
