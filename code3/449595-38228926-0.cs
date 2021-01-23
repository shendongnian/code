    public bool Verify()
    {
        using (X509Chain chain = new X509Chain())
        {
            // The defaults, but expressing it here for clarity
            chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
            chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            chain.ChainPolicy.VerificationTime = DateTime.Now;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
            return chain.Build(this);
        }
    }
