    private static void SetClientCredentialsSecurity(ClientCredentials clientCredentials)
    {
        clientCredentials.UserName.UserName = Settings.AppSettings.B2BUserName;
        clientCredentials.UserName.Password = Settings.AppSettings.B2BPassword;
        string directoryName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        clientCredentials.ServiceCertificate.DefaultCertificate = new X509Certificate2(Path.Combine(directoryName, Settings.AppSettings.B2BServerCertificateName));
        clientCredentials.ClientCertificate.Certificate = new X509Certificate2(Path.Combine(directoryName, Settings.AppSettings.B2BClientCertificateName), Settings.AppSettings.B2BClientCertificatePassword);
    }
