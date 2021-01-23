    public static string ComputeHash(string fileName)
    {
        using(FileStream st = File.OpenRead(fileName))
        {
             SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider());
             byte[] hash = sha1.ComputeHash(st);
             return BitConverter.ToString(hash).Replace("-", "");
        }
    }
     
