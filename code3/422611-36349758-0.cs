    foreach (X509Extension extension in certificate.Extensions)
    {
        if(extension.Oid.FriendlyName.Equals("Certificate Policies"))
        {
            Console.WriteLine(extension.Format(true));
        }
    }
