     private TfsTeamProjectCollection tfsServer = null;
     private VersionControlServer vcsServer = null;
     // This code is in a connection method
     tfsServer = new TfsTeamProjectCollection(new Uri (pServerName));
     tfsServer.EnsureAuthenticated();
    vcsServer = (VersionControlServer)tfsServer.GetService(typeof(VersionControlServer));
