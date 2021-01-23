                var serverUrl  = "";
                ICredentials credentials = new NetworkCredential(username, password, domain);
                ICredentialsProvider TFSProxyCredentials = new NetworkCredentialsProvider(credentials);
    
                TfsTeamProjectCollection currentCollection = new TfsTeamProjectCollection(new Uri(serverUrl), credentials);
    
    
                // Get the TFS Identity Management Service
                IIdentityManagementService identityManagementService = currentCollection.GetService<IIdentityManagementService>();
                // Look up the user that we want to impersonate
                TeamFoundationIdentity identity = identityManagementService.ReadIdentity(IdentitySearchFactor.AccountName, username, MembershipQuery.None, ReadIdentityOptions.None);
    
    
                // Open collection impersonated
                TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri(serverUrl), credentials, TFSProxyCredentials, identity.Descriptor);
        
                //For example we can access to service WorkItemStore 
                var workItemStore = tfs.GetService<WorkItemStore>();
