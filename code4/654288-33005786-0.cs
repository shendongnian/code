        ServicePointManager.ServerCertificateValidationCallback += Callback;
        static bool Callback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (IsInternalRequest(sender))
            {
                return true;
            }
            else
            {
                return IsExternalRequestValid(sender, certificate, chain, sslPolicyErrors);
            }
        }
