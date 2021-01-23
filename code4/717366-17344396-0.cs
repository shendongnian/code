            var provider = new AssertionFlowClient(
                GoogleAuthenticationServer.Description,
                new X509Certificate2(privateKeyPath, keyPassword, X509KeyStorageFlags.Exportable))
            {
                ServiceAccountId = serviceAccountEmail,
                Scope = DriveService.Scopes.Drive.GetStringValue(),
                ServiceAccountUser = driveHolderAccountEmail
            };
            var auth = new OAuth2Authenticator<AssertionFlowClient>(provider, AssertionFlowClient.GetState);
            m_service = new DriveService(new BaseClientService.Initializer()
            {
                Authenticator = auth
            });
