    // Get a reference to our Team Foundation Server. 
    TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("http://<yourserver>:8080/tfs/<yourcollection> "));
    // Get a reference to Version Control. 
    VersionControlServer versionControl = tpc.GetService<VersionControlServer>();
    Workspace workspace = versionControl.GetWorkspace("<local path to your workspace>");
    workspace.Get();
