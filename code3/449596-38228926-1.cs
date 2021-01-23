    using (X509Chain chain = new X509Chain())
    {
        // The defaults, but expressing it here for clarity
        chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
        chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
        chain.ChainPolicy.VerificationTime = DateTime.Now;
        chain.Build(cert);
        for (int i = 0; i < chain.ChainElements.Count; i++)
        {
            X509ChainElement element = chain.ChainElements[i];
            if (element.ChainElementStatus.Length != 0)
            {
                Console.WriteLine($"Error at depth {i}: {element.Certificate.Subject}");
                foreach (var status in element.ChainElementStatus)
                {
                    Console.WriteLine($"  {status.Status}: {status.StatusInformation}}}");
                }
            }
        }
    }
