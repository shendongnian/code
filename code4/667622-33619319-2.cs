    var publicKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
    var testData = Encoding.UTF8.GetBytes("testing");
    using ( var rsa = new RSACryptoServiceProvider(1024))
    {
        try
        {
            // client encrypting data with public key issued by server
            //
            rsa.FromXmlString(publicKey);
            var encryptedData = rsa.Encrypt(testData, true);
    
            var base64Encrypted = Convert.ToBase64String(encryptedData);
    
        }
        finally
        {
            rsa.PersistKeyInCsp = false;
        }
    }
