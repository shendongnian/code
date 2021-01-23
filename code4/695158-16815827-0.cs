        // Need class with TlsClient in inheritance chain
        class MyTlsClient : DefaultTlsClient
        {
            public override TlsAuthentication GetAuthentication()
            {
                return new MyTlsAuthentication();
            }
        }
        // Need class to handle certificate auth
        class MyTlsAuthentication : TlsAuthentication
        {
            public TlsCredentials GetClientCredentials(CertificateRequest certificateRequest)
            {
                // return client certificate
                return null;
            }
            public void NotifyServerCertificate(Certificate serverCertificate)
            {
                // validate server certificate
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Loopback, 6000);
                // input/output streams are deprecated, just pass client stream
                TlsProtocolHandler handler = new TlsProtocolHandler(client.GetStream());
                handler.Connect(new MyTlsClient());
                // handshake completed
                // use handler.Stream.Write/Read for sending app data
                Console.ReadLine();
            }
        }
