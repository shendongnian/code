    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
    String privateKey64 = "BwIAAACkAABSU0EyAAIAAAEAAQCFrMTqMU3T14zSUM5...";
    String EncryptedString = "PbauDOjqMLD2P6WSmEw==";
    byte[] EncryptedDataBlob = Convert.FromBase64String(EncryptedString);
    byte[] privateKeyBlob = Convert.FromBase64String(privateKey64);
    byte[] decryptedBytes;
    rsa.ImportCspBlob(privateKeyBlob);
    decryptedBytes = rsa.Decrypt(EncryptedDataBlob, false);
    String decryptedString =System.Text.Encoding.BigEndianUnicode.GetString(decryptedBytes);
