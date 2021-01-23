    Assembly asm = Assembly.LoadFrom("your_assembly.dll");
    string exe = asm.Location;
    System.Security.Cryptography.X509Certificates.X509Certificate executingCert =
       System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromSignedFile(exe); 
    Console.WriteLine (executingCert.Issuer);
