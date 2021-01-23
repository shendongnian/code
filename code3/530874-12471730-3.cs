    public static string Sign(string signatureBaseString, string signingKey)
    {
        var keyBytes = System.Text.Encoding.ASCII.GetBytes(signingKey);
        using (var myhmacsha1 = new System.Security.Cryptography.HMACSHA1(keyBytes)) {
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(signatureBaseString);
            var stream = new MemoryStream(byteArray);
            var signedValue = myhmacsha1.ComputeHash(stream);
            var result = Convert.ToBase64String(signedValue, Base64FormattingOptions.None);
            return result;
        }
    }
