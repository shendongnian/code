    TfsTeamProjectCollection projectCollection = new TfsTeamProjectCollection(new Uri("http://tfs.mycompany.com:8080/tfs/DefaultCollection"));
    VersionControlServer vc = projectCollection.GetService<VersionControlServer>();
    /* Get all pending changesets for all items (note, you can filter the items in the first arg.) */
    PendingSet[] pendingSets = vc.GetPendingSets(null, RecursionType.Full);
    foreach(PendingSet set in pendingSets)
    {
        /* Get each item in the pending changeset */
        foreach(PendingChange pc in set.PendingChanges)
        {
            Console.WriteLine(pc.ServerItem + " is checked out by " + set.OwnerName);
        }
    }
