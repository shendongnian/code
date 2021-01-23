    public override string ComputeSignature(string plainTextToEncode, string consumerSecret)
    {
        var key = PercentEncode(consumerSecret) + "&";
        try
        {
            using (var secretKey = new SecretKeySpec(key.GetBytes(), EncryptionMethods.HMACSHA1))
            using (Mac mac = new Mac(secretKey, plainTextToEncode))
            {
                return mac.AsBase64();
            }
        }
        finally
        {
            key = null;//free memory, remove sensitive data
        }
    }
   
