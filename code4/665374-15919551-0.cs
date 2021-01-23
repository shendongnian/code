        protected void WSFederationAuthenticationModule_SignInError(object sender, ErrorEventArgs e)
        {
            // handle an intermittent error that most often occurs if you are redirected to the STS after a session expired,
            // and the user clicks back on the browser - second error very uncommon but this should fix
            if (e.Exception.Message.StartsWith("ID4148") ||
                e.Exception.Message.StartsWith("ID4243") ||
                e.Exception.Message.StartsWith("ID4223"))
            {
                FederatedAuthentication.SessionAuthenticationModule.DeleteSessionTokenCookie();
                e.Cancel = true;
            }
        }
