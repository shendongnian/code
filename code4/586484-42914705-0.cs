        private UserSession LoginBySspiPackage(SspiPackageType sspiPackage, string serviceSpn)
        {
            Log($"Logging in to VSphere instance {VimClient.ServiceUrl} using SSPI.");
            var sspiClient = new SspiClient(serviceSpn, sspiPackage);
            var sessionManager = new SessionManager(VimClient, VimClient.ServiceContent.SessionManager);
            var serverNotReady = true;
            UserSession session = null;
            while (serverNotReady)
            {
                try
                {
                    var base64String = Convert.ToBase64String(sspiClient.Token);
                    session = sessionManager.LoginBySSPI(base64String, "en");
                    serverNotReady = false; // Connected!  
                }
                catch (VMware.Vim.VimException e)
                {
                    if (e.MethodFault is SSPIChallenge)
                    {
                        var sspiChallenge = e.MethodFault as SSPIChallenge;
                        var base64String = Convert.FromBase64String(sspiChallenge.Base64Token);
                        sspiClient.Initialize(base64String);
                    }
                    else if (e.MethodFault is InvalidLogin)
                    {
                        throw new InvalidLoginException(e.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return session;
        }
