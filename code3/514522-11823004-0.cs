    string sampletext = "text";
    System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1CryptoServiceProvider.Create();
    byte[] plainTextBytes = Encoding.UTF8.GetBytes(sampletext);
    byte[] hashBytes = hash.ComputeHash(plainTextBytes);
    foreach (byte b in hashBytes) {
        Console.Write(string.Format("{0:x2}", b));
    }
