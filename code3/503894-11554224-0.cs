    var collectionUrl = "http://tfsserver:8080/tfs/DefaultCollection";
    var tpc = new TfsTeamProjectCollection(collectionUrl);
   
    var vc = tpc.GetService<VersionControlServer>();
    // Get changeset #1234
    var cs = vc.GetChangeset(1234);
    // Get the last changeset checked into TFS by anyone.
    var cslatest = vs.GetChangeSet(vs.GetLatestChangesetId());    
    // Get a list of all changesets for the $/MyProject/Main branch
    var cslist = vc.QueryHistory("$/MyProject/Main", null, 0, RecursionType.Full, 
        null, null, int.MaxValue, false, false);
