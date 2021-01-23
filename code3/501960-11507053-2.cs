    using (StreamReader reader = File.OpenText(@"c:\RSA.txt"))
    {
        Org.BouncyCastle.OpenSsl.PemReader pr = 
            new Org.BouncyCastle.OpenSsl.PemReader(reader);
        Org.BouncyCastle.Utilities.IO.Pem.PemObject po = pr.ReadPemObject();
    
        Console.WriteLine("PemObject, Type: " + po.Type);
        Console.WriteLine("PemObject, Length: " + po.Content.Length);
    }
