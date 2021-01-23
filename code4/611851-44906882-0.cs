    void ExportPublicKey(X509Certificate2 cert, string filePath)
    {
    	byte[] encodedPublicKey = cert.PublicKey.EncodedKeyValue.RawData;
    	File.WriteAllLines(filePath, new[] {
    		"-----BEGIN PUBLIC KEY-----",
    		Convert.ToBase64String(encodedPublicKey, Base64FormattingOptions.InsertLineBreaks),
    		"-----END PUBLIC KEY-----",
    	});
    }
