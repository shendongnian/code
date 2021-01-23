    string project = "TeamProject1";
    string serverPath = "$/"+project;
    string computername = "myComputer"; // possibly Environment.Computer or something like that
    var tpc= TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(_tfsServerUri));
    tpc.Authenticate();
    // connect to VersionControl
    VersionControlServer sourceControl = (VersionControlServer)tpc.GetService(typeof(VersionControlServer));
    // iterate the local workspaces
    foreach (Workspace workspace in sourceControl.QueryWorkspaces(null, null, computername))
    {
      // check mapped folders
      foreach (WorkingFolder folder in workspace.Folders)
      {
        // e.g. $/TeamProject1 contains $/  if the root is mapped to local
        if (serverPath.Contains(folder.ServerItem) && !folder.IsCloaked)
         {
          Console.WriteLine(serverPath + " is mapped under "+ folder.LocalItem);
          Console.WriteLine("Workspacename: "+workspace.Name);
         }
      }
    } 
