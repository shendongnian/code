    Org.BouncyCastle.X509.X509Certificate cert = ...;
    using (FileStream fs = ...)
    {
        TextWriter w = new StreamWriter(fs);
        PemWriter pw = new PemWriter(w);
        pw.WriteObject(cert);
        pw.Writer.Close();
    }
