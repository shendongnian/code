    CspParameters cp = new CspParameters();
    cp.Flags = CspProviderFlags.NoPrompt | CspProviderFlags.UseExistingKey | 
                       CspProviderFlags.UseMachineKeyStore;
    cp.KeyContainerName = containerName;
    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp))
    {
        rsa.PersistKeyInCsp = false;
    }
