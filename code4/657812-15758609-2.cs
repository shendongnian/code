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
    public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
            return true;
        Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
        // Do not allow this client to communicate with unauthenticated servers. 
        return false;
    }
