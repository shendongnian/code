    static void Main(string[] args)
    {
        System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
        System.Security.Cryptography.RSAParameters rsaParam = rsa.ExportParameters(false);
        rsaParam.Modulus = Convert.FromBase64String(System.IO.File.ReadAllText(@"C:\keys\public_key.pem").Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", ""));
        rsa.ImportParameters(rsaParam);
        string msg = "This is a test.";
        byte[] encValue = rsa.Encrypt(Encoding.UTF8.GetBytes(msg), false);
        Console.WriteLine("Message Before Encryption: " + msg);
        Console.WriteLine("Encrypted Message:\r\n" + Convert.ToBase64String(encValue));
        Console.WriteLine("\r\nPress any key to exit.");
        Console.ReadKey();
    }
