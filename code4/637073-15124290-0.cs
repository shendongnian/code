    var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("some URI"));
    var identityService = tfs.GetService<IIdentityManagementService>();
    var identity = identity = identityService.ReadIdentity(
            IdentitySearchFactor.AccountName,
            "someuser", 
            MembershipQuery.None, 
            ReadIdentityOptions.None);
    var userTfs = new TfsTeamProjectCollection(tfs.Uri, identity.Descriptor);
