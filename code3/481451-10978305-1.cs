    Microsoft.TeamFoundation.VersionControl.Client 
    //this is just an example 
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("http://myserver:8080/"));
    VersionControlServer sourceControl = tpc.GetService<VersionControlServer>();
    return sourceControl.GetLatestChangesetId();
