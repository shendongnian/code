        public static LdapConnection GetLdapConnection(string login, string password)
        {
            var serverName = /*myServerNameFromConfig*/;
            var port = /*myPortFromConfig*/;
            LdapDirectoryIdentifier ldi = new LdapDirectoryIdentifier(string.Format("{0}:{1}", serverName, port));
            NetworkCredential nc = new NetworkCredential(login, password);
            LdapConnection connection = new LdapConnection(ldi, nc, System.DirectoryServices.Protocols.AuthType.Basic);
            connection.SessionOptions.ProtocolVersion = 3;
            connection.SessionOptions.VerifyServerCertificate =
                    new VerifyServerCertificateCallback((con, cer) => true);
            connection.SessionOptions.SecureSocketLayer = true;
            return connection;
        }
