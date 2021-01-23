            if (response == 'S')
            {
                //create empty collection
                X509CertificateCollection clientCertificates = new X509CertificateCollection();
                
                //trigger the callback to fetch some certificates
                context.DefaultProvideClientCertificatesCallback(clientCertificates);
                // Create SslStream, wrapping around NpgsqlStream
                SslStream sstream = new SslStream(stream, true, delegate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
                {
                    // Create callback to validate server cert here
                    return true;
                });
                sstream.AuthenticateAsClient(context.Host, clientCertificates, System.Security.Authentication.SslProtocols.Default, false);
                stream = sstream;
            }
