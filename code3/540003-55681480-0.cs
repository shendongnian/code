    ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(CertCheck);
    private static bool CertCheck(object sender, X509Certificate cert,
    X509Chain chain, System.Net.Security.SslPolicyErrors error)
    {
        return true;
    }
