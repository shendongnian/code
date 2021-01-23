    string file_path = @"your_file_path";
    WorkspaceInfo info = Workstation.Current.GetLocalWorkspaceInfo(file_path);
    Workspace ws = info.GetWorkspace(new TfsTeamProjectCollection(info.ServerUri));
    GetStatus status = ws.Get( new GetRequest(
                                              new ItemSpec ( file_path, RecursionType.Full ), 
                                              VersionSpec.Latest ), 
                                GetOptions.Preview );
    if(status.NoActionNeeded)
         MessegeBox.Show("Latest");
    else
         MessegeBox.Show("Not Latest");
