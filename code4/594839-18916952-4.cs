    public static string GetSignature(OAuthSignatureMethod signatureMethod,             AuthSignatureTreatment signatureTreatment, string signatureBase, string consumerSecret, string tokenSecret)
    {
        if (tokenSecret.IsNullOrBlank())
        {
            tokenSecret = String.Empty;
        }
        consumerSecret = UrlEncodeRelaxed(consumerSecret);
        tokenSecret = UrlEncodeRelaxed(tokenSecret);
        string signature;
        switch (signatureMethod)
        {
            case OAuthSignatureMethod.HmacSha1:
            {
                var crypto = new HMACSHA1();
                var key = "{0}&{1}".FormatWith(consumerSecret, tokenSecret);
                crypto.Key = _encoding.GetBytes(key);
                signature = signatureBase.HashWith(crypto);
                break;
            }
            case OAuthSignatureMethod.PlainText:
            {
                signature = "{0}&{1}".FormatWith(consumerSecret, tokenSecret);
                break;
            }
            default:
                throw new NotImplementedException("Only HMAC-SHA1 is currently supported.");
            }
            var result = signatureTreatment == OAuthSignatureTreatment.Escaped
                ? UrlEncodeRelaxed(signature)
                : signature;
            return result;
        }
