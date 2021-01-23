    public static void EncryptXmlFile(this XmlDocument doc, string elemToEncryptName)
    {
        if (doc == null)
            return;
        var security = new CryptoKeySecurity();
        // Give the creating user full access
        security.AddAccessRule(new CryptoKeyAccessRule(new NTAccount(Environment.UserDomainName, Environment.UserName), CryptoKeyRights.FullControl, AccessControlType.Allow));
        // Add read-only access to other users as required
        security.AddAccessRule(new CryptoKeyAccessRule(new NTAccount("<domain name>", "<user name>"), CryptoKeyRights.GenericRead, AccessControlType.Allow));
        // Specify that the key is to be stored in the machine key-store, and apply the security settings created above
        var cspParams = new CspParameters
        {
            KeyContainerName = containerName,
            Flags = CspProviderFlags.UseMachineKeyStore,
            CryptoKeySecurity = security
        };
        var rsaKey = new RSACryptoServiceProvider(cspParams);
        // Remainder of the method here...
