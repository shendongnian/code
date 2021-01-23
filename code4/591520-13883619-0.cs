    internal static bool ValidateCerts(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            // Good certificate.
            return true;
        }
        //Do custom validation here
    }
