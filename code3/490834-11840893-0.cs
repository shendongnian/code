    //Client
    var clientCredentialsBehavoir = behaviors.Find<FederatedClientCredentials>();
    clientCredentialsBehavoir.ServiceCertificate.Authentication.CertificateValidationMode =                     X509CertificateValidationMode.None;
    clientCredentialsBehavoir.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
    
    //The same can be done on the server
    var serviceConfiguration = new ServiceConfiguration();
    serviceConfiguration.CertificateValidationMode =   X509CertificateValidationMode.None;
