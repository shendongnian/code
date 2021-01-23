    // delegate definition for cert checking function
    private delegate bool CertFunc(X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors);
    // mapping between outbound requests and cert checking functions
    private static readonly ConcurrentDictionary<HttpWebRequest, CertFunc> _certFuncMap = new ConcurrentDictionary<HttpWebRequest, CertFunc>();
    // global cert callback
    private static bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
      // call back into the cert checking function that is associated with this request
      var httpWebRequest = (HttpWebRequest)sender;
      CertFunc certFunc = _certFuncMap[httpWebRequest];
      return certFunc(certificate, chain, sslPolicyErrors);
    }
