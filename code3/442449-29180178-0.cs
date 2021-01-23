    // Create site using server manager
    ServerManager sm = new ServerManager();
    Site mySite =  sm.Sites.Add("example.com", "C:\Test Website\", 443);
    // Creating binding object to store SSL cert
    var ibind = mySite.Bindings.CreateElement();
    ibind.Protocol = "https";
    ibind.BindingInformation = "*:443:" + domain;
    ibind.CertificateHash = certificate.GetCertHash();
    // This option will turn on SNI (server name indication)
    ibind.SetAttributeValue("sslFlags", 1);
    // Add the binding to the site
    mySite.Bindings.Add(ibind);
