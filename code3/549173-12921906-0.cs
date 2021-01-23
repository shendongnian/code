    var data        = {Get data that was signed as an array of bytes}
    var signature   = {Get signature as an array of bytes}
    
    // key variable is of type X509AsymmetricSecurityKey
    
    using(var rsa = key.GetAsymmetricAlgorithm(SecurityAlgorithms.RsaSha256Signature, false) as RSACryptoServiceProvider)
    {
        if(rsa != null)
        {
            using(var halg = new SHA256CryptoServiceProvider())
            {
                if (!rsa.VerifyData(data, halg, signature))
                {
                    throw new SecurityException("Signature is invalid.");
                }
            }
        }
    }
