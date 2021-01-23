    public static AsymmetricAlgorithm ToDotNetKey(RsaPrivateCrtKeyParameters privateKey)
    {
        var cspParams = new CspParameters
        {
              KeyContainerName = Guid.NewGuid().ToString(),
              KeyNumber = (int)KeyNumber.Exchange,
              Flags = CspProviderFlags.UseMachineKeyStore
        };
        var rsaProvider = new RSACryptoServiceProvider(cspParams);
        // ...
