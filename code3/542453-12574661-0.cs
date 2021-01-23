    @using System.Security.Cryptography;
    static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
    {
     HashAlgorithm algorithm = new SHA256Managed();
     byte[] plainTextWithSaltBytes = 
      new byte[plainText.Length + salt.Length];
     for (int i = 0; i < plainText.Length; i++)
     {
      plainTextWithSaltBytes[i] = plainText[i];
     }
     for (int i = 0; i < salt.Length; i++)
     { 
      plainTextWithSaltBytes[plainText.Length + i] = salt[i];
     }
     return algorithm.ComputeHash(plainTextWithSaltBytes);            
    }
