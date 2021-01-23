    public override string ComputeSignature(string signatureBaseString, string consumerSecret)
    {
        var key = PercentEncode(consumerSecret) + "&";
        var secretKey = new SecretKeySpec(key.GetBytes(), EncryptionMethods.HMACSHA1);
        using (Mac mac = new Mac(secretKey, signatureBaseString))
        {
            return mac.AsBase64();
        }
    }
