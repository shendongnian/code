        public virtual string GetSignature(string consumerSecret, string tokenSecret, string uri, string method, params ParameterSet[] parameters)
        {
            var allParameters = parameters.SelectMany(p => p.ToList()).ToArray();
            var parametersString = CalculateSignatureBaseString(allParameters);
            var signatureBaseString = OAuth1aUtil.CalcualteSignatureBaseString(method, uri, parametersString);
            var sigingKey = GetSigningKey(consumerSecret, tokenSecret);
            var signature = Sign(signatureBaseString, sigingKey);
            return signature;
        }
