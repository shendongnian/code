    public abstract class OAuthSigner
    {
        /// <summary>
        /// Signature method used
        /// </summary>
        /// <returns>a string that tells the implementation method</returns>
        public abstract string GetSignatureMethod();
    
        /// <summary>
        /// computes the signature that is used with the encryption based on the keys provided by cardinity
        /// </summary>
        /// <param name="signatureBaseString">The secret string that services as a base</param>
        /// <param name="consumerSecret">The consumer key as specified in the API settings</param>
        /// <returns>signature string computed by the provided parameters using the signature method</returns>
        public abstract string ComputeSignature(String signatureBaseString, String consumerSecret);
    
        /// <summary>
        /// Encode a string into a format expected by Cardinity
        /// </summary>
        /// <param name="textToEncode">The text that is to be encoded</param>
        /// <returns>web encoded string ready for using to send to Cardinity</returns>
        public static String PercentEncode(string textToEncode)
        {
    
            return string.IsNullOrEmpty(textToEncode)
                ?""
                : UrlEncoder.Default.Encode(Cardinity.ENCODING.GetString(Cardinity.ENCODING.GetBytes(textToEncode)))
                    .Replace("+", "%20").Replace("*", "%2A")
                    .Replace("%7E", "~");
    
        }
    }
