    var smartCardCerts = new List<X509Certificate2>();
    var myStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    foreach(X509Certificate2 cert in myStore)
    {
      if( !cert.HasPrivateKey ) continue; // not smartcard for sure
      var rsa = cert.PrivateKey as RSACryptoServiceProvider;
      if( rsa==null ) continue; // not smart card cert again
      if( rsa.CspKeyContainerInfo.HardwareDevice ) // sure - smartcard
      {
         // inspect rsa.CspKeyContainerInfo.KeyContainerName Property
         // or rsa.CspKeyContainerInfo.ProviderName (your smartcard provider, such as 
         // "Schlumberger Cryptographic Service Provider" for Schlumberger Cryptoflex 4K
         // card, etc
      }
    }
