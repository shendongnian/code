    public static void DecryptXmlFile(this XmlDocument doc)
    {
        if (doc == null)
            return;
        // Specify that the key is to be loaded from the machine key-store, and not to create a new key if it doesn't exist.
        var cspParams = new CspParameters
        {
            KeyContainerName = containerName,
            Flags = CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseExistingKey
        };
        var rsaKey = new RSACryptoServiceProvider(cspParams);
        // Remainder of the method here...
