                // Select target CSP
                cspParams = new CspParameters();
                cspParams.ProviderType = 1; // PROV_RSA_FULL 
                rsaProvider = new RSACryptoServiceProvider(cspParams);
                // Read public key from file
                publicKeyFile = File.OpenText(publicKeyFileName);
                publicKeyText = publicKeyFile.ReadToEnd();
                // Import public key
                rsaProvider.FromXmlString(publicKeyText);
             
