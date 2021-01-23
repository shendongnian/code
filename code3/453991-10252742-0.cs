    TeamProjectPicker tpp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, true);
    tpp.ShowDialog();
    
    var tpc = tpp.SelectedTeamProjectCollection;
    
    VersionControlServer versionControl = tpc.GetService<VersionControlServer>();
    
    var tp = versionControl.GetTeamProject("MyTeamProject");
    var path = tp.ServerItem;
    
    var q = versionControl.QueryHistory(path, VersionSpec.Latest, 0, RecursionType.Full, null, VersionSpec.Latest, VersionSpec.Latest, Int32.MaxValue, true, true, false, false);
    
    Changeset latest = q.Cast<Changeset>().First();
    
    // The number of the changeset
    int id = latest.ChangesetId;
