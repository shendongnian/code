        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            if (error == SslPolicyErrors.None)
            {
                // check expiration date - and raise an alert if expiring soon
                //
                return true;
            }
        }
