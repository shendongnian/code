    FileStream fs = new FileStream("your_cert_file.crt", FileMode.Open);
    byte[] certBytes = new byte[fs.Length];
    fs.Read(certBytes, 0, (Int32)fs.Length);
    fs.Close();
    System.Security.Cryptography.X509Certificates.X509Certificate x509cert = 
        new X509Certificate(certBytes);
    Console.WriteLine(x509cert.GetPublicKey());
    Console.WriteLine(x509cert.GetPublicKeyString());
