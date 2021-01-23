    public string writeVBScriptDecrypt(string nameFile)
    {
      var base64EncryptedBytes = File.ReadAllText(nameFile);
      byte[] bytes = Convert.FromBase64String(base64EncryptedBytes);
      ...
    }
