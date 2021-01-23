    public X509Certificate2 DownloadSslCertificate(string strDNSEntry)
    {
        X509Certificate2 cert = null;
        using (TcpClient client = new TcpClient())
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;           
            client.Connect(strDNSEntry, 443);
            SslStream ssl = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
            try
            {
                ssl.AuthenticateAsClient(strDNSEntry);
            }
            catch (AuthenticationException e)
            {
                log.Debug(e.Message);
                ssl.Close();
                client.Close();
                return cert;
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
                ssl.Close();
                client.Close();
                return cert;
            }
            cert = new X509Certificate2(ssl.RemoteCertificate);
            ssl.Close();
            client.Close();
            return cert;
        }
    }
