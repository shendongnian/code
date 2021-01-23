    WCF supports the following credential types when you are using message level security:
    
    Windows. The client uses a Windows token representing the logged in user’s Windows identity. The service uses the credentials of the process identity or an SSL certificate. You will use this in the sample application that demonstrates the first scenario (internal self-hosted service).
    UserName. The client passes a user name and password to the service. Typically, the user will enter the user name and password in a login dialog box. The service can validate the user name and password using a Windows account or the ASP.NET membership provider. You will use this in the sample application that demonstrates the third scenario (public Web-hosted service).
    Certificate. The client uses an X.509 certificate and the service uses either that certificate or an SSL certificate.
    IssueToken. The client and service use the Secure Token Service, which issues tokens the client and service trust. Windows CardSpace uses the Secure Token Service.
    None. The service does not validate the client.
