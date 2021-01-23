    // register the global cert callback
    ServicePointManager.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
    // create the request object
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
    // cert checking function
    CertFunc certFunc = (certificate, chain, sslPolicyErrors) =>
    {
      // perform cert logic here
      return true;
    };
    _certFuncMap[httpWebRequest] = certFunc;
    using (var webResponse = httpWebRequest.GetResponse())
    {
      // process the response...
    }
    // clean up the mapping
    _certFuncMap.TryRemove(httpWebRequest, out certFunc);
