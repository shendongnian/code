    ServicePointManager.ServerCertificateValidationCallback = 
        delegate(object sender1,
                 System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                 System.Security.Cryptography.X509Certificates.X509Chain chain,
                 System.Net.Security.SslPolicyErrors sslPolicyErrors) 
        { return true; };
