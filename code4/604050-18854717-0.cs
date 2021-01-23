    // get private key information
    ICspAsymmetricAlgorithm key = (ICspAsymmetricAlgorithm)certificate.PrivateKey;
    const int PVK_TYPE_KEYCONTAINER = 2;
    
    var providerInfo = new SignerProviderInfo
    {
       cbSize = (uint)Marshal.SizeOf(typeof(SignerProviderInfo)),
       pwszProviderName = key.CspKeyContainerInfo.ProviderName,
       dwProviderType = (uint)key.CspKeyContainerInfo.ProviderType,
       dwPvkChoice = PVK_TYPE_KEYCONTAINER,
       providerUnion = new SignerProviderInfo.ProviderInfoUnion
       {
           pwszKeyContainer = key.CspKeyContainerInfo.KeyContainerName
       },
    };
